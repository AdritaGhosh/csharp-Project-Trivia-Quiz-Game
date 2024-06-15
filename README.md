# Features 

**Multiple Quiz Categories**: Science, History, and Math.
<br>
**Question Handling**: Load questions from text files for each category.
<br>
**Answer Validation**: Limits on both incorrect and invalid attempts.
<br>
**Score Management**: Records and saves player scores with timestamps.
<br>
**Randomization**: Ensures questions are randomly selected without repetition.

## How It Works

**Player Registration**:
<br>
Player is prompted to enter their name.
<br>
Personalized welcome message is displayed.

**Category Selection**:
<br>
Player selects from available quiz categories.
<br>
Questions are loaded from respective files (SciQstn.txt, HistQstn.txt, MathQstn.txt).

**Question Display and Answer Validation**:
<br>
Each question is displayed with multiple-choice options.
<br>
Player inputs their answer.
<br>
Input validation checks for correct and invalid attempts.
<br>
Score is updated based on the correctness of the answers.

**Score Calculation and Display**:
<br>
Final score is calculated and displayed.
<br>
Scores are saved to a file using the ScoreFile procedure.

**Error Handling**:
<br>
Try-catch blocks manage file I/O exceptions and input errors.
<br>
Detailed error messages help in debugging.

## Code Structure

**Main Program**: Entry point where player registration, category selection, and game loop are managed.

## Procedures

**GetPlayerName**: Captures player's name.
<br>
**LoadQuizQuestionsFromFile**: Loads questions from text files.
<br>
**CategorySelectionInput**: Manages category selection input.
<br>
**AnswerSelectionFromChoices**: Handles answer input validation.
<br>
**AskQuizQuestion**: Displays questions and processes answers.
<br>
**ScoreFile**: Saves the player’s score to a file.

## Modifications and Bug Fixes

**Key Changes**
<br>
*Flow Chart*: Initial planning of game structure and checkpoints.
<br>
*Namespace and Class Setup*: Declared variables and setup main procedures.
<br>
*File I/O and Lists*: Utilized System.Collections.Generic and System.IO for managing quiz data.
<br>
*Structure for Questions*: Created QuizQuestions structure to store question details.
<br>
*Error Handling*: Implemented try-catch blocks and resolved various exceptions.
<br>
*Randomization*: Added random selection of questions to avoid repetition.
<br>
*Score Logging*: Integrated score saving with player details and timestamps.
<br>
*Console Management*: Cleared console after each question for better user experience.

**Resolved Issues**
<br>
*File Loading Errors*: Corrected file naming inconsistencies and fixed array bounds issues.
<br>
*Input Validation*: Managed both invalid and incorrect attempts.
<br>
*Question Repetition*: Used .RemoveAt method to prevent question repetition.

**Resources and References**
<br>
*Stack Overflow*: Various solutions for List handling and file I/O.
<br>
*Microsoft Documentation*: Guidelines on C# methods and error handling.
<br>
*freeCodeCamp*: Randomization techniques and best practices.
