using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class ScadaBUS
    {
        private readonly ScadaDAL _scadaDAL;
        private CancellationTokenSource _cts;
        private readonly Random _random;
        private int _cycleCounter;

        public event Action<ScadaTelemetryDTO> OnTelemetryReceived;
        public bool IsMonitoring { get; private set; }

        public ScadaBUS()
        {
            _scadaDAL = new ScadaDAL();
            _random = new Random();
            _cycleCounter = 0;
            IsMonitoring = false;
        }

        public List<SubstationDTO> GetSubstations() => _scadaDAL.GetAllSubstations();

        public void StartMonitoring(SubstationDTO substation)
        {
            if (IsMonitoring || substation == null) return;

            IsMonitoring = true;
            _cycleCounter = 0;
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            // Vòng lặp nền chạy định kỳ mỗi 2000 ms (2 giây) trong Task.Run(...) với CancellationTokenSource
            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        _cycleCounter++;

                        double voltage = Math.Round(108.0 + (_random.NextDouble() * (115.0 - 108.0)), 2);
                        double loadPercent = Math.Round(50.0 + (_random.NextDouble() * (98.0 - 50.0)), 1);

                        var telemetry = new ScadaTelemetryDTO
                        {
                            SubstationID = substation.SubstationID,
                            SubstationName = substation.SubstationName,
                            Timestamp = DateTime.Now,
                            VoltageKV = voltage,
                            LoadPercent = loadPercent,
                            CycleCount = _cycleCounter
                        };

                        if (telemetry.IsOverloaded)
                        {
                            _scadaDAL.InsertGridOverloadLog(new GridOverloadLogDTO
                            {
                                SubstationID = telemetry.SubstationID,
                                SubstationName = telemetry.SubstationName,
                                RecordedTime = telemetry.Timestamp,
                                VoltageKV = telemetry.VoltageKV,
                                LoadPercent = telemetry.LoadPercent,
                                StatusMessage = telemetry.StatusMessage
                            });
                        }

                        OnTelemetryReceived?.Invoke(telemetry);

                        await Task.Delay(2000, token);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
            }, token);
        }

        public void StopMonitoring()
        {
            if (!IsMonitoring) return;

            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
            IsMonitoring = false;
        }
    }
}
