Create table DogOwner(          
    Id					INT IDENTITY(1,1) NOT NULL,              
    DogName				VARCHAR(50) NOT NULL,          
    DogType				VARCHAR(50) NOT NULL,
	DogAge				TINYINT NOT NULL,
	DogDob				DATETIME NOT NULL, 
	CreatedDate			DATETIME default CURRENT_TIMESTAMP,
	LastUpdatedDate		DATETIME default CURRENT_TIMESTAMP        
) 


Create table UserType(          
    Id					INT IDENTITY(1,1) NOT NULL,          
    Description			VARCHAR(200) NOT NULL,
	CreatedDate			DATETIME default CURRENT_TIMESTAMP,
	LastUpdatedDate		DATETIME default CURRENT_TIMESTAMP                      
) 


Create table AppUser(          
    Id					INT IDENTITY(1,1) NOT NULL, 
	FirstName			VARCHAR(50) NOT NULL,          
    LastName			VARCHAR(50) NOT NULL, 
	Sex					BIT NOT NULL,
	Address				VARCHAR(220)  NULL,  
    Email				VARCHAR(30) NOT NULL,   
    ContactNo			VARCHAR(20) NOT NULL,        
    RegNo				VARCHAR(200) NOT NULL,
	PassWord			VARCHAR(20) NOT NULL,
	UserType			TINYINT NOT NULL,
	StaffId				INT NULL,
	DogOwnerId			INT NULL,
	CreatedDate			DATETIME default CURRENT_TIMESTAMP,
	LastUpdatedDate		DATETIME default CURRENT_TIMESTAMP                       
) 

Create table Staff(          
    Id					INT IDENTITY(1,1) NOT NULL,             
    Qualification		VARCHAR(255) NOT NULL,          
    Experience			VARCHAR(255) NOT NULL,
	Dob					DATETIME NOT NULL,
	CreatedDate			DATETIME default CURRENT_TIMESTAMP,
	LastUpdatedDate		DATETIME default CURRENT_TIMESTAMP           
) 