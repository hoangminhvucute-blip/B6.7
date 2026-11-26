using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ScadaDAL : DBConnection
    {
        public List<SubstationDTO> GetAllSubstations()
        {
            var list = new List<SubstationDTO>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT SubstationID, SubstationName, NominalVoltageKV, SafeLoadThreshold, Location FROM Substations";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new SubstationDTO
                            {
                                SubstationID = reader["SubstationID"].ToString(),
                                SubstationName = reader["SubstationName"].ToString(),
                                NominalVoltageKV = Convert.ToDouble(reader["NominalVoltageKV"]),
                                SafeLoadThreshold = Convert.ToDouble(reader["SafeLoadThreshold"]),
                                Location = reader["Location"].ToString()
                            });
                        }
                    }
                }
            }
            catch
            {
                // Danh sách trạm dự phòng nếu chạy ngay mà chưa tạo CSDL PowerGridScadaDB
                list.Add(new SubstationDTO { SubstationID = "TBA_HD110", SubstationName = "Trạm 110kV Hà Đông", NominalVoltageKV = 110.0, SafeLoadThreshold = 85.0, Location = "Hà Đông, Hà Nội" });
                list.Add(new SubstationDTO { SubstationID = "TBA_CH220", SubstationName = "Trạm 220kV Chèm", NominalVoltageKV = 220.0, SafeLoadThreshold = 85.0, Location = "Bắc Từ Liêm, Hà Nội" });
                list.Add(new SubstationDTO { SubstationID = "TBA_LB110", SubstationName = "Trạm 110kV Long Biên", NominalVoltageKV = 110.0, SafeLoadThreshold = 85.0, Location = "Long Biên, Hà Nội" });
            }
            return list;
        }

        public bool InsertGridOverloadLog(GridOverloadLogDTO log)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertGridOverloadLog", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubstationID", log.SubstationID);
                        cmd.Parameters.AddWithValue("@SubstationName", log.SubstationName);
                        cmd.Parameters.AddWithValue("@RecordedTime", log.RecordedTime);
                        cmd.Parameters.AddWithValue("@VoltageKV", log.VoltageKV);
                        cmd.Parameters.AddWithValue("@LoadPercent", log.LoadPercent);
                        cmd.Parameters.AddWithValue("@StatusMessage", log.StatusMessage);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
