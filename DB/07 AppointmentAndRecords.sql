Create table AppointmentAndRecords(          
    Id					INT IDENTITY(1,1) NOT NULL,    
	UserId				INT,            
    Vacination			VARCHAR(220),          
    HRecord				VARCHAR(220),
	CreatedDate			DATETIME default CURRENT_TIMESTAMP,
	LastUpdatedDate		DATETIME default CURRENT_TIMESTAMP        
) 