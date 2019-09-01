Create table DntType(          
    [Id]					INT IDENTITY(1,1) NOT NULL,              
	[Description]			VARCHAR(100) NOT NULL,
	[CreatedDate]			DATETIME default CURRENT_TIMESTAMP,
	[LastUpdatedDate]		DATETIME default CURRENT_TIMESTAMP        
) 