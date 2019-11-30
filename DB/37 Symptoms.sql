Create table Symptoms(          
    [Id]					INT IDENTITY(1,1) NOT NULL,              
    [Title]					VARCHAR(100) NOT NULL,
	[Description]			VARCHAR(100) NOT NULL,
	[CreatedDate]			DATETIME default CURRENT_TIMESTAMP,
	[LastUpdatedDate]		DATETIME default CURRENT_TIMESTAMP        
) 


Create table DiseasesSymptoms(          
    [Id]					INT IDENTITY(1,1) NOT NULL,              
    [DntId]					INT NOT NULL,
	[SymptomsId]			INT NOT NULL,
	[CreatedDate]			DATETIME default CURRENT_TIMESTAMP,
	[LastUpdatedDate]		DATETIME default CURRENT_TIMESTAMP        
) 

USE [VeteDB]
GO

INSERT INTO [dbo].[Symptoms]
           ([Title]
           ,[Description])
     VALUES
           ('Runny eyes'
           ,'Runny eyes')

		   ,('Fever'
           ,'Fever')

		   ,('Coughing'
           ,'Coughing')

		   ,('Vomiting'
           ,'Vomiting')

		   ,('Paralysis'
           ,'Paralysis')

		   ,('Lethargy'
           ,'Lethargy')

		   ,('Diarrhea'
           ,'Diarrhea')

		   ,('Dehydration'
           ,'Dehydration')

		   ,('Weight loss'
           ,'Weight loss')

		   ,('Respiratory problems'
           ,'Respiratory problems')

		   ,('Heart disease'
           ,'Heart disease')

		   ,('Pain'
           ,'Pain')

		   ,('Hyperactivity'
           ,'Hyperactivity')

		   ,('Loss of appetite'
           ,'Loss of appetite')

		   ,('Limping'
           ,'Limping')

		   ,('Heavy coughing'
           ,'Heavy coughing')

		   ,('Gagging'
           ,'Gagging')

		   ,('Muscle tenderness'
           ,'Muscle tenderness')

		   ,('Jaundice'
           ,'Jaundice')

		   ,('Increased urination and thirst'
           ,'Increased urination and thirst')

		   ,('Enlarge lymph nodes'
           ,'Enlarge lymph nodes')

		   ,('Oral tumors on the lips, the gums or the tongue'
           ,'Oral tumors on the lips, the gums or the tongue')

GO


