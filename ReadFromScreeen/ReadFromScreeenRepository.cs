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
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ReadFromScreeen
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ReadFromScreeenRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.1")]
    [RepositoryFolder("c29c181a-5096-4365-919c-4ce58bc9aac9")]
    public partial class ReadFromScreeenRepository : RepoGenBaseFolder
    {
        static ReadFromScreeenRepository instance = new ReadFromScreeenRepository();

        /// <summary>
        /// Gets the singleton class instance representing the ReadFromScreeenRepository element repository.
        /// </summary>
        [RepositoryFolder("c29c181a-5096-4365-919c-4ce58bc9aac9")]
        public static ReadFromScreeenRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ReadFromScreeenRepository() 
            : base("ReadFromScreeenRepository", "/", null, 0, false, "c29c181a-5096-4365-919c-4ce58bc9aac9", ".\\RepositoryImages\\ReadFromScreeenRepositoryc29c181a.rximgres")
        {
        }

#region Variables

        string _textFromScreen = "111222333";

        /// <summary>
        /// Gets or sets the value of variable textFromScreen.
        /// </summary>
        [TestVariable("28bc372c-77ef-4f47-885d-2fd5c210ec08")]
        public string textFromScreen
        {
            get { return _textFromScreen; }
            set { _textFromScreen = value; }
        }

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("c29c181a-5096-4365-919c-4ce58bc9aac9")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.1")]
    public partial class ReadFromScreeenRepositoryFolders
    {
    }
#pragma warning restore 0436
}