-- =============================================
-- BÀI TẬP 6.7: TRUNG TÂM ĐIỀU ĐỘ & GIÁM SÁT LƯỚI ĐIỆN THỜI GIAN THỰC
-- Database: PowerGridScadaDB
-- Bảng: Substations, GridOverloadLogs
-- =============================================

CREATE DATABASE PowerGridScadaDB;
GO

USE PowerGridScadaDB;
GO

CREATE TABLE Substations (
    SubstationID NVARCHAR(20) PRIMARY KEY,
    SubstationName NVARCHAR(100) NOT NULL,
    NominalVoltageKV FLOAT NOT NULL,
    SafeLoadThreshold FLOAT NOT NULL DEFAULT 85.0,
    Location NVARCHAR(200)
);
GO

CREATE TABLE GridOverloadLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    SubstationID NVARCHAR(20) NOT NULL,
    SubstationName NVARCHAR(100) NOT NULL,
    RecordedTime DATETIME NOT NULL DEFAULT GETDATE(),
    VoltageKV FLOAT NOT NULL,
    LoadPercent FLOAT NOT NULL,
    StatusMessage NVARCHAR(255) NOT NULL,
    FOREIGN KEY (SubstationID) REFERENCES Substations(SubstationID)
);
GO

INSERT INTO Substations (SubstationID, SubstationName, NominalVoltageKV, SafeLoadThreshold, Location)
VALUES 
    ('TBA_HD110', N'Trạm 110kV Hà Đông', 110.0, 85.0, N'Quận Hà Đông, Hà Nội'),
    ('TBA_CH220', N'Trạm 220kV Chèm', 220.0, 85.0, N'Quận Bắc Từ Liêm, Hà Nội'),
    ('TBA_LB110', N'Trạm 110kV Long Biên', 110.0, 85.0, N'Quận Long Biên, Hà Nội');
GO

CREATE PROCEDURE sp_InsertGridOverloadLog
    @SubstationID NVARCHAR(20),
    @SubstationName NVARCHAR(100),
    @RecordedTime DATETIME,
    @VoltageKV FLOAT,
    @LoadPercent FLOAT,
    @StatusMessage NVARCHAR(255)
AS
BEGIN
    INSERT INTO GridOverloadLogs (SubstationID, SubstationName, RecordedTime, VoltageKV, LoadPercent, StatusMessage)
    VALUES (@SubstationID, @SubstationName, @RecordedTime, @VoltageKV, @LoadPercent, @StatusMessage);
END
GO
