using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrackingComputerLibrary.Machines;

namespace TrackingComputerLibrary
{
    public class Program
    {
        #region Variables
        List<Building> computer = new List<Building>();

        Building buildingOne = new Building("Philadelphia");
        Building buildingTwo = new Building("Madrid");

        CardReader cr1;
        CardReader cr2;
        CardReader cr3;

        Door dr1;
        Door dr2;
        Door dr3;

        LedPanel lp1;
        LedPanel lp2;
        LedPanel lp3;

        Speaker sp1;
        Speaker sp2;
        Speaker sp3;
        #endregion

        static void Main(string[] args)
        {
            Program pr = new Program();

            pr.Greetings();

            pr.TreeGenerator();

            Task t1 = new Task(pr.AutomaticStuff);
            t1.Start();
            t1.Wait();

            pr.Comamnding();
        }

        public void TreeGenerator()
        {
            Console.WriteLine("Creating structure!");

            buildingOne.MachinesInBuilding = new List<IMachine>();
            buildingTwo.MachinesInBuilding = new List<IMachine>();

            cr1 = new CardReader("AccessCardAdmin", "A01234DE7FFF");
            cr2 = new CardReader("AccessCardUserOne", "A01234DE7FFF");
            cr3 = new CardReader("AccessCardUserTwo", "A01234DE7FFF");

            dr1 = new Door("MainHallDoor", State.Locked);
            dr2 = new Door("LabOneDoor", State.Locked);
            dr3 = new Door("LabTwoDoor", State.Locked);

            lp1 = new LedPanel("LedPanelEntrance", "Welcome to our company");
            lp2 = new LedPanel("LedPanelLabOne", "Safety first!");
            lp3 = new LedPanel("LedPanelLabTwo", "Caution! Wet floor!");

            sp1 = new Speaker("SpeakerFireAlarm", 134.45E-2f, SoundType.Alarm); // 1.3445
            sp2 = new Speaker("SpeakerLabOneMusic", 20.20E-1f, SoundType.Music); // 2.020
            sp3 = new Speaker("SpeakerLabTwoMusic", 19.19E-1f, SoundType.Alarm); // 1.919

            buildingOne.MachinesInBuilding.Add(cr1);
            buildingOne.MachinesInBuilding.Add(cr2);
            buildingTwo.MachinesInBuilding.Add(cr3);

            buildingOne.MachinesInBuilding.Add(dr1);
            buildingTwo.MachinesInBuilding.Add(dr2);
            buildingTwo.MachinesInBuilding.Add(dr3);

            buildingTwo.MachinesInBuilding.Add(lp1);
            buildingOne.MachinesInBuilding.Add(lp2);
            buildingOne.MachinesInBuilding.Add(lp3);

            buildingTwo.MachinesInBuilding.Add(sp1);
            buildingOne.MachinesInBuilding.Add(sp2);
            buildingTwo.MachinesInBuilding.Add(sp3);

            computer.Add(buildingOne);
            computer.Add(buildingTwo);

            Console.WriteLine("Structure created!");
        }

        public void AutomaticStuff()
        {
            Thread.Sleep(1000);
            Door dr4 = new Door("MainEntranceDoor", State.Locked);

            Thread.Sleep(1000);
            buildingTwo.MachinesInBuilding.Add(dr4);

            Thread.Sleep(1000);
            buildingTwo.MachinesInBuilding.Remove(cr1);

            Thread.Sleep(1000);
            buildingTwo.MachinesInBuilding.Remove(cr1);

            Thread.Sleep(1000);
            buildingOne.MachinesInBuilding.Add(cr1);

            Thread.Sleep(1000);
            cr1.Name = "AccessCardGuest";

            Thread.Sleep(1000);
            lp3.Message = "Floor is safe to use!";

            Thread.Sleep(1000);
            dr1.Status = State.Open;

            Thread.Sleep(1000);
            dr2.Status = State.Open;

            Thread.Sleep(1000);
            dr3.Status = State.Open;

            Thread.Sleep(1000);
            sp1.Volume = 9000.92E-4f; //0.900092

        }

        public void Greetings()
        {
            Console.WriteLine("Welcome to our awesome company!");
        }

        public void Spacer()
        {
            Console.WriteLine("");
        }

        public void Comamnding()
        {
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("Enter your command:");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "exit":
                        exit = true;
                        break;


                    case "building one":
                        Spacer();
                        for (int i = 0; i < buildingOne.MachinesInBuilding.Count; i++)
                        {
                            Console.WriteLine(buildingOne.MachinesInBuilding[i].Name);
                        }
                        Spacer();
                        break;


                    case "building two":
                        Spacer();
                        for (int i = 0; i < buildingTwo.MachinesInBuilding.Count; i++)
                        {
                            Console.WriteLine(buildingTwo.MachinesInBuilding[i].Name);
                        }
                        Spacer();
                        break;


                    case "lLed panel message":
                        Console.WriteLine("Insert name of led panel:");
                        string chooseLedPanel = Console.ReadLine();                    

                        Console.WriteLine("Insert new message:");
                        string newMessage = Console.ReadLine();

                        foreach (Building building in computer)
                        {
                            foreach (IMachine machine in building.MachinesInBuilding)
                            {
                                if (machine is LedPanel lpanel)
                                {
                                    if (lpanel.Name == chooseLedPanel)
                                    {
                                        lpanel.Message = newMessage;
                                    }
                                }
                            }                        
                        }    
                        break;


                    case "door handle":
                        Console.WriteLine("Insert name of door:");
                        string chooseDoor = Console.ReadLine();

                        Console.WriteLine("Insert command (0 - Lock, 1 - Open):");
                        int chooseDoorStatus = Convert.ToInt32(Console.ReadLine());

                        foreach (Building building in computer)
                        {
                            foreach (IMachine machine in building.MachinesInBuilding)
                            {
                                if (machine is Door drr)
                                {
                                    if (drr.Name == chooseDoor)
                                    {
                                        if (chooseDoorStatus == 0)
                                        {
                                            drr.Status = State.Locked;
                                        }
                                        else if (chooseDoorStatus == 1)
                                        {
                                            drr.Status = State.Open;
                                        }
                                    }
                                }
                            }
                        }
                        break;


                    case "card reader name":
                        Console.WriteLine("Insert name of card reader:");
                        string chooseCardReader = Console.ReadLine();

                        Console.WriteLine("Insert new name:");
                        string newName = Console.ReadLine();                        

                        foreach (Building building in computer)
                        {
                            foreach (IMachine machine in building.MachinesInBuilding)
                            {
                                if (machine is CardReader creader)
                                {
                                    if (creader.Name == chooseCardReader)
                                    {
                                        creader.Name = newName;
                                    }
                                }
                            }
                        }
                        break;


                    case "speaker volume":
                        Console.WriteLine("Insert name of speaker:");
                        string chooseSpeakerName = Console.ReadLine();

                        Console.WriteLine("Insert volume:");
                        float chooseSpeakerVolume = Convert.ToSingle(Console.ReadLine());
                       
                        foreach (Building building in computer)
                        {
                            foreach (IMachine machine in building.MachinesInBuilding)
                            {
                                if (machine is Speaker speak)
                                {
                                    if (speak.Name == chooseSpeakerName)
                                    {
                                        speak.Volume = chooseSpeakerVolume;
                                    }
                                }
                            }
                        }
                        break;


                    case "speaker state":
                        Console.WriteLine("Insert name of speaker:");
                        chooseSpeakerName = Console.ReadLine();

                        Console.WriteLine("Insert command (0 - None, 1 - Alarm, 2 - Music):");
                        int chooseSpeakerStatus = Convert.ToInt32(Console.ReadLine());

                        foreach (Building building in computer)
                        {
                            foreach (IMachine machine in building.MachinesInBuilding)
                            {
                                if (machine is Speaker speak)
                                {
                                    if (speak.Name == chooseSpeakerName)
                                    {
                                        if (chooseSpeakerStatus == 0)
                                        {
                                            speak.Sound = SoundType.None;
                                        }
                                        else if (chooseSpeakerStatus == 1)
                                        {
                                            speak.Sound = SoundType.Music;
                                        }
                                        else if (chooseSpeakerStatus == 2)
                                        {
                                            speak.Sound = SoundType.Alarm;
                                        }
                                    }
                                }
                            }
                        }
                        break;


                    case "remove machine":
                        Console.WriteLine("Insert name of machine:");
                        string chooseMachineToDelete = Console.ReadLine();

                        foreach (Building building in computer)
                        {
                            foreach (IMachine machine in building.MachinesInBuilding)
                            {
                                if (machine.Name == chooseMachineToDelete)
                                {
                                    building.MachinesInBuilding.Remove(machine);
                                    break;
                                }
                            }
                        }
                        break;


                    case "move machine":
                        Console.WriteLine("Insert name of machine:");
                        string chooseMachineToAdd = Console.ReadLine();

                        Console.WriteLine("Insert building where to move:");
                        string chooseBuildingToAdd = Console.ReadLine();

                        foreach (Building building in computer)
                        {
                            foreach (IMachine machine in building.MachinesInBuilding)
                            {
                                if (machine.Name == chooseMachineToAdd)
                                {
                                    foreach (Building bld in computer)
                                    {
                                        if (bld.Name == chooseBuildingToAdd)
                                        {
                                            bld.MachinesInBuilding.Add(machine);
                                            building.MachinesInBuilding.Remove(machine);
                                            break;
                                        }
                                    }
                                    break;
                                }             
                            }
                        }
                        break;


                    default:
                        Console.WriteLine("invalid command!");
                        break;              
                }
            }
        }
    }
}
