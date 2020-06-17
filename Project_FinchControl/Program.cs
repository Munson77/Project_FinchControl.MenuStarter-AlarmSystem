using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Velis, John
    // Dated Created: 1/22/2020
    // Last Modified: 1/25/2020
    //
    // **************************************************

    
    //Summary//
    // user Commands
    //Summary//

    public enum Command
    {
        NONE,
        MOVEFOWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTTEMPUTURE,
        DONE
    }

    class Program
    {
        private static object boolinput;

        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DisplayDataRecorderMenuScreen(finchRobot);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        //UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\td) Main Menu");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDancing(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":
                        DisplayMenuScreen();
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(120,150,30);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dancing                  *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDancing(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dancing");

            Console.WriteLine("\tThe Finch robot will not show off its dance moves!");
            DisplayContinuePrompt();

            finchRobot.setMotors(255, -255);

            Console.WriteLine("Please press any key to go to menu.");
            Console.ReadLine();

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing it up                 *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it up");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(98);
                finchRobot.noteOn(196);
                finchRobot.noteOn(392);
                finchRobot.setMotors(50, -60);
            }

            Console.WriteLine("Please press any key to go to menu.");
            Console.ReadLine();

            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region Data Recorder

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder                             *
        /// *****************************************************************
        /// </summary>

        static void DisplayDataRecorderMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;
            //int numberOfDataPoints;
            //Double dataPointFrequency;
            //Double[] temperatures;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DataRecorderDisplayGetNumberOfDataPoints(myFinch);
                        break;

                    case "b":
                        DataRecorderDisplayGetDataPointFrequency(myFinch);
                        break;

                    case "c":
                        DataRecorderDisplayGetData(5, 10.0, myFinch);
                        break;

                    case "d":
                        //DisplayShowData(myFinch);
                        break;

                    case "q":
                        DisplayMenuScreen();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);
            

            /// <summary>
            /// *****************************************************************
            /// *               Data Recorder-- Number of Data Points           *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>

            void DataRecorderDisplayGetNumberOfDataPoints(Finch finchRobot)
            {
                Console.CursorVisible = false;
                DisplayScreenHeader("Data Points");
                Console.WriteLine("What is the number of the reading?");
                
                int result = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(result);

                   
                Console.WriteLine("Please press any key to go to menu.");
                Console.ReadLine();

                DisplayMenuPrompt("Data Recorder menu");

            }
            /// <summary>
            /// *****************************************************************
            /// *               Data Recorder-- Frequincy of Data Points        *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>

            void DataRecorderDisplayGetDataPointFrequency(Finch finchRobot)
            {
                Console.CursorVisible = false;
                DisplayScreenHeader("Data Point frequency");

                Console.WriteLine("What is the frequency of the readings in seconds?");
                double userInput = Convert.ToInt32(Console.ReadLine());
                double frequency = userInput;
                string mySentence = String.Format("The frequency is {0}", frequency);
                Console.WriteLine(mySentence);

                Console.WriteLine("Please press any key to go to menu.");
                Console.ReadLine();

                DisplayMenuPrompt("Data Recorder menu");

            }


            /// <summary>
            /// *****************************************************************
            /// *               Data Recorder-- Get Data Points                 *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>

            void DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
            {
                Console.CursorVisible = false;
                DisplayScreenHeader("Get data");

                Double[] temperature;
                for (int numberOfPoints = 0; numberOfPoints < numberOfDataPoints; numberOfPoints++)
                {
                    finchRobot.getTemperature();
                    int result = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(result);
                    Console.Write("Enter the amount of celsius: ");
                    int celsius = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Fahrenheit = {0}", celsius * 18 / 10 + 32);
                }

                Console.WriteLine("Please press any key to go to menu.");
                Console.ReadLine();


                DisplayMenuPrompt("Data Recorder menu");

            }


        }
        #endregion

        #region Alarm System 
        static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitAlarmSystemMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Alarm System menu");
                String sensorsToMonitor;
                String rangeType;
                int minMaxThresholdValue;
                int timeToMonitor;

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Maximum/Minimum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tf) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAlarmDisplaySetRangeType(finchRobot);
                        break;

                    case "b":
                        LightAlarmDisplaySetMinMaxThresholdValue(finchRobot);
                        break;

                    case "c":

                        break;

                    case "d":

                        break;
                    case "e":

                        break;
                    case "f":
                        DisplayMenuScreen();
                        break;




                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
                /// <summary>
                /// *****************************************************************
                /// *  Alarm system            *
                /// *****************************************************************
                /// </summary>
                /// <param name="finchRobot">finch robot object</param>

                void DisplayLightAlarmDisplaySetRangeType(Finch finchRobot)

                     Console.CursorVisible = false;

                DisplayScreenHeader("Range type");
                


            }

            

            DisplayMenuPrompt("Alarm System Menu");

            /// <summary>
            /// *****************************************************************
            /// *  Alarm system            *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            /// 
            int LightAlarmDisplaySetMinMaxThresholdValue(string rangeType, Finch finchRobot)

                 DisplayScreenHeader("Min Max Threchold");

            int min(int x, int y)
            {
                return (x < y) ? x : y;
            }
        }
        #endregion

        #region User


        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.getTemperature();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
