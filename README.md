
# VU ML Data Aggregation Interface Fall 2021

This project is a tool used for recording and storing patient stress levels.


## Authors

- Matthew Schroder 
- Curtis Taylor
- Austin Witherow
- Tyler Vongpanya
- Andrew Johnson




## Deployment

This project was created using Unity 2020.3.16f1. 

Deployment of this application will require updating line 78 
in the Assets/Scripts/Summary.cs file to write to the desired folder path. This 
line writes out the session information to a json array file containing other 
session information.



## Documentation

####  Interface
---

- #### Menu Page
  - Holds 3 (patient id, name, experiemnt code) optional input components that the user can fill out. They are not necessary and the next page can be accessed without them. 

- #### Main Page
  - An interface that has 3 buttons to indicate signs on stress (low, medium, or high) and corresponding counters that increase with each button press. There is a button at the bottom that takes the user to the summary page.

- #### Summary Page
  - The summary page shows a review of the clicks and displays the length of the session. There are buttons to end the session and start a new session at the bottom. The end session button closes the application and the next session restarts at the menu page.

  #### Backend code
  ---
  - #### App Data
    - Contains nested C# classes that reflect the JSON object output. 
    - Default values are assigned where necessary so that users don't have to enter optional data.
    - These classes include...
        - SessionData - The top level C# class
        - SessionMetaData
        - Data
        - ButtonData
        - Time

  - #### App Manager
    - Contains one singleton class "Session" 
    - The Session class instantiates a new version of the SessionData class and holds a single instance of itself that is shared between the various page scripts below
    - There is one Print() function that prints out a json representation of the current SessionData object.
  
  - #### Menu script
    - Instantiates a new GameObject for the name, patient id, and experiment code that are found in the interface. 
    - Accesses the singleton instance of Session made by the AppManager.
    - Has one function MenuToMain() that handles the transition from the menu page to the main page. This function is fired when the next button is clicked and assigns the values entered to the appropriate variables in the SessionData class. 

  - #### Main script
    - Instantiates a new SessionData.Data.Time list to store time signatures for each button click and GameObjects to hold the current number of clicks for each button.
    - Accesses the singleton instance of Session made by the AppManager.
    - Has 4 functions
      - MainToSummary() - Simply calls SceneManager.LoadScene() to move to the Summary page
      - High() - Increments the SessionData.Data.buttons.high and records the time of the click
      - Med() - Increments the SessionData.Data.buttons.medium and records the time of the click
      - Low() - Increments the SessionData.Data.buttons.low and records the time of the click


  - #### Summary script
    - Instantiates the Text objects used to display the SessionData values in the UI. 
      - Has 5 functions 
      - Awake() - Handles instantiating the values displayed in the UI and setting metadata about the session.
      - GetJsonSessions() - Reads the current DataStore.json file and returns it as C# object of type List<SessionData>
      - NextSession() - Calls write session, resets the Session.SessionData, and loads the menu page.
      - EndSession() - Calls write session, resets the Session.SessionData, and closes the application.
      - WriteSession() 
        - Reads a DataStore.json file into a new List<SessionData>. If this is empty the function creates a new List<SessionData> containing only the data from the last session otherwise it appends the most recent session to the end of the list and writes it back out to the DataStore.json file. There is 
        - Will likely want to change the read and write paths in a production environment.

