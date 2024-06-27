# Trivia-Quiz-Game

## Features 

* **Multiple Quiz Categories**: Science, History, and Math.
* **Question Handling**: Load questions from text files for each category.
* **Answer Validation**: Limits on both incorrect and invalid attempts.
* **Score Management**: Records and saves player scores with timestamps.
* **Randomization**: Ensures questions are randomly selected without repetition.

## How It Works

* **Player Registration**:
Player is prompted to enter their name.
<br>
Personalized welcome message is displayed.

* **Category Selection**:
Player selects from available quiz categories.
<br>
Questions are loaded from respective files (SciQstn.txt, HistQstn.txt, MathQstn.txt).

* **Question Display and Answer Validation**:
Each question is displayed with multiple-choice options.
<br>
Player inputs their answer.
<br>
Input validation checks for correct and invalid attempts.
<br>
Score is updated based on the correctness of the answers.

* **Score Calculation and Display**:
Final score is calculated and displayed.
<br>
Scores are saved to a file using the ScoreFile procedure.

* **Error Handling**:
Try-catch blocks manage file I/O exceptions and input errors.
<br>
Detailed error messages help in debugging.

## Code Structure

**Main Program**: Entry point where player registration, category selection, and game loop are managed.

## Procedures

* **GetPlayerName**: Captures player's name.
* **LoadQuizQuestionsFromFile**: Loads questions from text files.
* **CategorySelectionInput**: Manages category selection input.
* **AnswerSelectionFromChoices**: Handles answer input validation.
* **AskQuizQuestion**: Displays questions and processes answers.
* **ScoreFile**: Saves the player’s score to a file.

## Modifications and Bug Fixes

**Key Changes**
<br>
* *Flow Chart*: Initial planning of game structure and checkpoints.
* *Namespace and Class Setup*: Declared variables and setup main procedures.
* *File I/O and Lists*: Utilized System.Collections.Generic and System.IO for managing quiz data.
* *Structure for Questions*: Created QuizQuestions structure to store question details.
* *Error Handling*: Implemented try-catch blocks and resolved various exceptions.
* *Randomization*: Added random selection of questions to avoid repetition.
* *Score Logging*: Integrated score saving with player details and timestamps.
* *Console Management*: Cleared console after each question for better user experience.

**Resolved Issues**
<br>
* *File Loading Errors*: Corrected file naming inconsistencies and fixed array bounds issues.
* *Input Validation*: Managed both invalid and incorrect attempts.
* *Question Repetition*: Used .RemoveAt method to prevent question repetition.

**Resources and References**
<br>
* *Stack Overflow*: Various solutions for List handling and file I/O.
* *Microsoft Documentation*: Guidelines on C# methods and error handling.
* *freeCodeCamp*: Randomization techniques and best practices.
