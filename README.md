## Stock and Buy Code Contest

##### Table of Contents  
[input](#input)  
[Database Design](#db) 

[EF Migration](#migration) 
<a name="input"/>
##### Input as a JSON
{
    "Children": [
      {
        "Children": [],
      "Name": "Seat",
      "RequiredUnits": 1,
      "TotalUnits": 50
      },
    {
        "Children": [],
      "Name": "Pedals",
      "RequiredUnits": 2,
      "TotalUnits": 60
    },
    {
        "Children": [
          {
            "Children": [],
          "Name": "Frame",
          "RequiredUnits": 2,
          "TotalUnits": 60
          },
        {
            "Children": [],
          "Name": "Tube",
          "RequiredUnits": 2,
          "TotalUnits": 35
        }
      ],
      "Name": "Wheels",
      "RequiredUnits": 2,
      "TotalUnits": 0
    }
  ],
  "Name": "Bike",
  "RequiredUnits": 0,
  "TotalUnits": 0
}
<a name="db"/>
##### [Database design can be found at] 
(https://github.com/imzahoorshah/StockAndBuy/blob/master/Docs/Database%20Design.pptx)

<a name="migration"/>
##### Run the following commands in StockAndBuy.EF library for DB Migration
ENable-Migrations
Add Migration 'initial migration'
Update-Database

