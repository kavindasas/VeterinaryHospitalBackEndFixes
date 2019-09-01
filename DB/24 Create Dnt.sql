Create table Dnt(          
    [Id]					INT IDENTITY(1,1) NOT NULL,              
    [Title]					VARCHAR(100) NOT NULL,          
    [Url]					VARCHAR(150) NOT NULL,
	[Description]			VARCHAR(400) NOT NULL,
	[Type]					INT,
	[CreatedDate]			DATETIME default CURRENT_TIMESTAMP,
	[LastUpdatedDate]		DATETIME default CURRENT_TIMESTAMP        
) 