-- =========================
-- DATABASE: ClientManagementSystem
-- =========================
CREATE DATABASE ClientManagementSystem;
GO
USE ClientManagementSystem;
GO

-- =========================
-- TABLE: Roles
-- =========================
CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(100) NOT NULL
);
GO

-- =========================
-- TABLE: Agents
-- =========================
CREATE TABLE Agents (
    AgentID INT IDENTITY(1,1) PRIMARY KEY,
    RoleID INT NOT NULL,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
GO

-- =========================
-- TABLE: Clients
-- =========================
CREATE TABLE Clients (
    ClientID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100),
    AccountHistory NVARCHAR(MAX)
);
GO

-- =========================
-- TABLE: Users
-- =========================
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(50) NOT NULL, -- 'Admin' or 'Agent'
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- =========================
-- TABLE: ActionLogs
-- =========================
CREATE TABLE ActionLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    Action NVARCHAR(255) NOT NULL,
    IPAddress NVARCHAR(45) NULL,
    Timestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- =========================
-- OPTIONAL RELATIONSHIPS
-- =========================
-- If Agents are Users with a specific role:
ALTER TABLE Agents
ADD CONSTRAINT FK_Agents_Users FOREIGN KEY (RoleID)
REFERENCES Roles(RoleID);
GO

-- Indexes for performance
CREATE INDEX IX_Clients_Email ON Clients(Email);
CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_ActionLogs_UserID ON ActionLogs(UserID);
GO
