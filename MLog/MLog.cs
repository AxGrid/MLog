﻿using System;
using SmartFormat;

namespace AxGrid
{

    public class ILog
    {
        
        public static bool ShowDebug = true;
        public static bool ShowInfo = true;
        public static bool ShowWarn = true;
        public static bool ShowError = true;
        
        public void Debug(string s)
        {
           if (ShowDebug) UnityEngine.Debug.Log(s);
        }
        
        public void Info(string s)
        {
            if (ShowInfo) UnityEngine.Debug.Log(s);
        }
        
        public void Warn(string s)
        {
            if (ShowWarn) UnityEngine.Debug.LogWarning(s);
        }
        
        public void Warn(Exception e)
        {
            if (ShowWarn) UnityEngine.Debug.LogWarning(e);
        }

        public void Error(string s)
        {
            if (ShowError) UnityEngine.Debug.LogError(s);
        }

        public void Error(Exception e)
        {
            if (ShowError) UnityEngine.Debug.LogException(e);
        }
    }
    
    
    public class MLog
    {
        private ILog log;
        public void Debug(string message, params object[] args){ log.Debug(args.Length == 0 ? message : Smart.Format(message, args)); }
        public void Info(string message, params object[] args) {
            log.Info(args.Length == 0 ? message : Smart.Format(message, args));
        }
        public void Warn(string message, params object[] args){ log.Warn(args.Length == 0 ? message : Smart.Format(message, args)); }
        
        public void Warn(Exception e){ log.Warn($"{e.Message}\n{e.StackTrace}"); }

        
        public void Error(string message, params object[] args){ log.Error(args.Length == 0 ? message : Smart.Format(message, args)); }

        public void Error(Exception e, string message, params object[] args)
        {
            log.Error(args.Length == 0 ? message : Smart.Format(message, args) + $"\n{e.Message}\n{e.StackTrace}");
        }

        public void Error(Exception e)
        {
            log.Error($"{e.Message}\n{e.StackTrace}");
        }

        public MLog(Type type)
        {
            log = new ILog();
        }

        public MLog(string name)
        {
            log = new ILog();
        }
    }
    
    public static class Log {
        
        private static readonly MLog log = new MLog("client");
        public static void Debug(string message, params object[] args){  log.Debug(message, args); }
        public static void Info(string message, params object[] args){ log.Info(message, args); }
        public static void Warn(string message, params object[] args){  log.Warn(message, args); }
        
        public static void Warn(Exception e){ log.Warn(e); }
        public static void Error(string message, params object[] args){ log.Error(message, args); }

        public static void Error(Exception e, string message, params object[] args)
        {
            log.Error(e,message,args);
        }

        public static void Error(Exception e)
        {
            log.Error(e);
        }
    }
    
}