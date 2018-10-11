﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace ReadFromScreeen
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The FollowRead recording.
    /// </summary>
    [TestModule("e89062f4-a84e-4604-9ad9-5b6f5ae0560c", ModuleType.Recording, 1)]
    public partial class FollowRead : ITestModule
    {
        /// <summary>
        /// Holds an instance of the BisAutotestRepository repository.
        /// </summary>
        public static BisAutotestRepository repo = BisAutotestRepository.Instance;

        static FollowRead instance = new FollowRead();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public FollowRead()
        {
            controlVar = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static FollowRead Instance
        {
            get { return instance; }
        }

#region Variables

        /// <summary>
        /// Gets or sets the value of variable controlVar.
        /// </summary>
        [TestVariable("f59bd2f6-97de-437f-a2da-ba5460109bfe")]
        public string controlVar
        {
            get { return repo.controlVar; }
            set { repo.controlVar = value; }
        }

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.1")]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.1")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Bis.Putty.GetFromScreen("БАЗОВЫЙ ", ValueConverter.ArgumentFromString<int>("len", "6"), "controlVar");
            Delay.Milliseconds(0);
            
            Bis.Putty.PrintTextFromScreen("controlVar");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
