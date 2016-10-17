-- Problem 1
SELECT [Name], 
	ISNULL([Description], 'No description') AS [Description]
FROM [PhotographySystem].[dbo].[Albums]
ORDER BY [Name]

-- Problem 2
SELECT photographs.[Title], albums.[Name]
FROM [PhotographySystem].[dbo].[Albums] AS albums
  JOIN [PhotographySystem].[dbo].[AlbumsPhotographs] AS AlbumsPhotographs 
	ON albums.Id = AlbumsPhotographs.AlbumId
  JOIN [PhotographySystem].[dbo].[Photographs] AS photographs 
	ON AlbumsPhotographs.PhotographId = photographs.Id
ORDER BY albums.[Name] ASC, photographs.[Title] DESC

-- Problem 3
SELECT photographs.[Title], 
	   photographs.[Link], 
	   photographs.[Description],
	   categories.[Name] AS CategoryName,
	   users.[FullName] AS Author
FROM [PhotographySystem].[dbo].Photographs AS photographs
   JOIN [PhotographySystem].[dbo].[Categories] AS categories
	ON photographs.CategoryId = categories.Id
   JOIN [PhotographySystem].[dbo].[Users] AS users
    ON photographs.UserId = users.Id
 WHERE photographs.[Description] IS NOT NULL
ORDER BY photographs.[Title]

-- Problem 4
SELECT users.[Username], 
	   users.[FullName], 
	   users.[BirthDate], 
	   ISNULL(photographs.[Title], 'No photos') AS Photo
FROM [PhotographySystem].[dbo].[Users] AS users
  LEFT JOIN [PhotographySystem].[dbo].[Photographs] AS photographs
   ON users.Id = photographs.UserId
 WHERE MONTH(users.[BirthDate]) = 1
ORDER BY users.[FullName] ASC

-- Problem 5
SELECT photographs.[Title],		
       cameras.[Model] AS CameraModel,
	   lenses.[Model] AS LensModel
FROM [PhotographySystem].[dbo].[Photographs] AS photographs
  JOIN [PhotographySystem].[dbo].[Equipments] AS equipments
   ON photographs.EquipmentId = equipments.Id
  JOIN [PhotographySystem].[dbo].[Cameras] AS cameras
	ON equipments.CameraId = cameras.Id
  JOIN [PhotographySystem].[dbo].[Lenses] AS lenses
   ON equipments.LensId = lenses.Id
ORDER BY photographs.[Title] ASC

-- Problem 6
SELECT photographs.[Title],
	   categories.[Name] AS [Category Name],
	   cameras.[Model],
	   manufactures.[Name] AS [Manufacturer Name],
	   cameras.[Megapixels],
	   cameras.[Price]
FROM [PhotographySystem].[dbo].[Photographs] AS photographs
  JOIN [PhotographySystem].[dbo].[Categories] AS categories
   ON photographs.CategoryId = categories.Id
  JOIN [PhotographySystem].[dbo].[Equipments] AS equipments
	ON photographs.EquipmentId = equipments.Id
  JOIN [PhotographySystem].[dbo].[Cameras] AS cameras
   ON equipments.CameraId = cameras.Id
  JOIN [PhotographySystem].[dbo].[Manufacturers] AS manufactures
   ON cameras.ManufacturerId = manufactures.Id
WHERE cameras.[Price] = (SELECT MAX(cameras2.[Price])
						 FROM [PhotographySystem].[dbo].[Categories] AS categories2
						   JOIN [PhotographySystem].[dbo].[Photographs] AS photographs2
						    ON photographs2.CategoryId = categories2.Id
						   JOIN [PhotographySystem].[dbo].[Equipments] AS equipments2
						    ON photographs2.EquipmentId = equipments2.Id
						   JOIN [PhotographySystem].[dbo].[Cameras] AS cameras2
						    ON equipments2.CameraId = cameras2.Id
						 WHERE categories2.Id = categories.Id
						 GROUP BY categories2.[Name])
ORDER BY cameras.[Price] DESC, photographs.[Title] ASC

-- Problem 7
SELECT manufactures.[Name],
	   cameras.[Model],
	   REPLACE(cameras.[Price], ',', '.') AS [Price]
FROM [PhotographySystem].[dbo].[Manufacturers] AS manufactures
	JOIN [PhotographySystem].[dbo].[Cameras] AS cameras
	ON cameras.ManufacturerId = manufactures.Id
WHERE cameras.[Price] > (SELECT AVG(cameras2.Price) 
						 FROM [PhotographySystem].[dbo].[Cameras] AS cameras2
						 WHERE cameras2.Price IS NOT NULL)
ORDER BY cameras.[Price] DESC, cameras.[Model] ASC

-- Problem 8
SELECT manufacturers.[Name], SUM(lenses.[Price]) AS [Total Sum]
FROM [PhotographySystem].[dbo].[Lenses] as lenses	
	JOIN [PhotographySystem].[dbo].[Manufacturers] as manufacturers
	 ON lenses.ManufacturerId = manufacturers.Id
GROUP BY manufacturers.[Name]

-- Problem 9
SELECT users.[FullName]
	   ,manufacturers.[Name] AS [Manufacturer]
	   ,cameras.[Model] AS [Camera Model]
	   ,cameras.Megapixels
FROM [PhotographySystem].[dbo].[Cameras] AS cameras
	JOIN [PhotographySystem].[dbo].[Manufacturers] as manufacturers
	 ON cameras.ManufacturerId = manufacturers.Id
	JOIN [PhotographySystem].[dbo].[Equipments] AS equipments
	 ON equipments.CameraId = cameras.Id
	JOIN [PhotographySystem].[dbo].[Users] AS users
	 ON users.EquipmentId = equipments.Id
WHERE cameras.Year < 2015
ORDER BY users.[FullName]

-- Problem 10
SELECT lenses.[Type], COUNT(lenses.[Id]) AS [Count]
FROM [PhotographySystem].[dbo].[Lenses] AS lenses
GROUP BY lenses.[Type]
ORDER BY [Count] DESC, lenses.[Type] ASC

-- Problem 11
SELECT users.Username, users.FullName
FROM [PhotographySystem].[dbo].[Users] AS users
ORDER BY (LEN(users.Username) + LEN(users.FullName)), users.BirthDate DESC

-- Problem 12
SELECT users.Username, users.FullName
FROM [PhotographySystem].[dbo].[Users] AS users
ORDER BY (LEN(users.Username) + LEN(users.FullName)), users.BirthDate DESC

-- Problem 13
UPDATE cameras
SET cameras.[Price] = cameras.[Price] - (SELECT AVG(cameras1.[Price])
										 FROM Cameras AS cameras1
							     		 WHERE cameras.ManufacturerId = cameras1.ManufacturerId) * 
					 (SELECT LEN(m1.[Name]) / 100
					  FROM Manufacturers AS m1
					  WHERE m1.Id = cameras.ManufacturerId) 
FROM Cameras AS cameras

SELECT rs.Model, rs.Price, rs.ManufacturerId 
FROM (
    SELECT Model,Price,ManufacturerId, Rank() 
        over (Partition BY ManufacturerId
            ORDER BY Price DESC ) AS Rank
    FROM Cameras
    ) rs WHERE Rank <= 3 AND Price IS NOT NULL