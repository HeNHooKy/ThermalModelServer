
CREATE TABLE Cluster (
	Id uniqueidentifier
	, [Name] nvarchar(500) NULL 
	, PRIMARY KEY (Id)
);

CREATE TABLE [Block] (
	Id uniqueidentifier
	, ClusterId uniqueidentifier FOREIGN KEY REFERENCES Cluster(Id)
	, Number int
	, [Name] nvarchar(500) NULL 
	, PRIMARY KEY (Id)
	, UNIQUE (ClusterId, Number)
);

CREATE TABLE Sensor (
	Id uniqueidentifier
	, BlockId uniqueidentifier FOREIGN KEY REFERENCES [Block](Id)
	, Number int
	, LastCheck datetime NULL
	, LastValue nvarchar(255) NULL
	, [Name] nvarchar(500) NULL 
	, CoordX nvarchar(255) NULL
	, CoordY nvarchar(255) NULL
	, CoordZ nvarchar(255) NULL
	, PRIMARY KEY (Id)
	, UNIQUE (BlockId, Number)
);


CREATE TABLE [Data] (
	SensorId uniqueidentifier FOREIGN KEY REFERENCES Sensor(Id)
	, CheckDate datetime
	, [Value] nvarchar(255)
	PRIMARY KEY (SensorId, CheckDate)
);
