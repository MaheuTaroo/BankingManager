using System;
using System.Diagnostics;
using BankingManagerDataLib.Helpers;

namespace BankingManagerDesktopUI.ViewModels
{
    public abstract class BaseViewModel : Observable
    {
        public void OnException(Exception ex) => Debug.Print(ex.ToString());
    }
}