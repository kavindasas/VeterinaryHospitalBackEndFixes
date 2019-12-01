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

Create table VaccineSchedule(          
	[Id]					INT IDENTITY(1,1) NOT NULL,
	[Description]			VARCHAR(200) NOT NULL,
	[OwnerId]				INT,
	[CreatedUserId]			INT,
	[LastUpdatedUserId]		INT,
	[CreatedDate]			DATETIME default CURRENT_TIMESTAMP,
	[LastUpdatedDate]		DATETIME default CURRENT_TIMESTAMP        
) 


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


	INSERT INTO [dbo].[Dnt]
		   ([Title]
		   ,[Url]
		   ,[Description])
	 VALUES
		   ('Canine distemper'
		   ,''
		   ,'A-seizure medications and medications to help control vomiting and diarrhea. Antibiotics are also often used to treat secondary bacterial infections that may be present as well.')
		   
		   ,('Canine parvovirus (parvo)'
		   ,''
		   ,'Vets treat dogs with parvo by providing plenty of fluids, electrolytes and secondary infection prevention.')
		   
		   ,('Heartworm'
		   ,''
		   ,'Expect a rigorous regimen of steroids, antibiotics, and an organic arsenic injection.')

		   ,('Rabies'
		   ,''
		   ,'There is no treatment for dogs once they contract rabies, and it is fatal. ')

		   ,('Lyme disease'
		   ,''
		   ,'Lyme disease can be treated with antibiotics and prevented by getting him vaccinated and checking his body for ticks after outdoor exposure.')

		   ,('Kennel cough'
		   ,''
		   ,'Your vet will prescribe antibiotics, cough suppressants and plenty of rest. ')

		   ,('Leptospirosis'
		   ,''
		   ,'Vets can providing antibiotics and supportive care, it’s easier to prevent by simply getting your dog vaccinated.')

		   ,('Kidney disease'
		   ,''
		   ,'Vet will prescribe medications and kidney-friendly diets, but the best way to prevent it is by catching it early. Regular vet checkups and appointments keep your dog’s health on track.')

		   ,('Lymphoma'
		   ,''
		   ,'Oral and injectable drugs given on a weekly basis. Some commonly used drugs include cyclophosphamide, vincristine, doxorubicin, and prednisone. ')

		   ,('Mouth Sores'
		   ,''
		   ,'Special shampoos, antibiotics, or antifungals may be prescribed for any secondary bacterial or fungal infections.')


		   INSERT INTO [dbo].[DiseasesSymptoms]
		   ([DntId]
		   ,[SymptomsId])
	 VALUES
		   (7
		   ,1)
		   ,(7
		   ,2)
		   ,(7
		   ,3)
		   ,(7
		   ,4)
		   ,(7
		   ,5)

		   ,(8
		   ,2)
		   ,(8
		   ,6)
		   ,(8
		   ,4)
		   ,(8
		   ,7)
		   ,(8
		   ,8)
		   ,(8
		   ,9)

		   ,(9
		   ,6)
		   ,(9
		   ,3)
		   ,(9
		   ,10)
		   ,(9
		   ,11)
		   ,(9
		   ,9)

		   ,(10
		   ,2)
		   ,(10
		   ,12)
		   ,(10
		   ,13)

		   ,(11
		   ,12)
		   ,(11
		   ,14)
		   ,(11
		   ,2)
		   ,(11
		   ,15)

		   ,(12
		   ,16)
		   ,(12
		   ,17)
		   ,(12
		   ,6)

		   ,(13
		   ,2)
		   ,(13
		   ,18)
		   ,(13
		   ,6)
		   ,(13
		   ,8)
		   ,(13
		   ,4)
		   ,(13
		   ,19)

		   ,(14
		   ,9)
		   ,(14
		   ,20)
		   ,(14
		   ,14)
		   ,(14
		   ,4)
		   
		   ,(15
		   ,4)
		   ,(15
		   ,3)
		   ,(15
		   ,9)
		   ,(15
		   ,21)

		   ,(16
		   ,22)

GO

ALTER TABLE [dbo].[VaccineSchedule]
ADD IsEnded BIT; 
