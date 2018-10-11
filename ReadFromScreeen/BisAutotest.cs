/*
 * Created by Ranorex
 * User: admin
 * Date: 28.11.2017
 * Time: 15:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using System.Diagnostics;
using System.Reflection;
using ReadFromScreeen;

namespace Bis
{
	[UserCodeCollection]
	public class Putty
	{
		/// <summary>
		/// Проверка наличия (или отсутствия - задается параметром absentFlag) строк на экране,
		/// перечисленных в параметрах вызова функции.
		/// Параметры:
		/// absentFlag = False (по умолчанию) - строки ДОЛЖНЫ БЫТЬ на экране.
		/// absentFlag = True - указанных строк НЕ должно быть на экране.
		/// compareText - compareText6 - строки для поиска, каждая из которых
		/// может быть регулярным выражением.
		/// Вхождение каждой строки ищется отдельно - порядок их следования не важен.
		/// Первая строка не должна быть пустой.
		/// </summary>
		[UserCodeMethod]
		
		public static void OnScreen ( bool absentFlag, string compareText, string compareText2, string compareText3,
		                             string compareText4, string compareText5, string compareText6)
		{
			Delay.Duration(Utility.FirstDelay, false);
			Utility.CopyPuttyToClipboard();
			if(compareText != "")
				// Utility.ClipboardContains6( compareText, compareText2, compareText3, compareText4, compareText5, compareText6, absentFlag );
				Utility.ClipboardContains( compareText, Utility.NumAttempts, absentFlag );
			else throw new Ranorex.RanorexException ("Ошибка вызова функции OnScreen! Первая строка-параметр не должна быть пустой!");
			
			
			if(compareText2 != "")
				Utility.ClipboardContains( compareText2, Utility.NumAttempts, absentFlag );
			if(compareText3 != "")
				Utility.ClipboardContains( compareText3, Utility.NumAttempts, absentFlag );
			if(compareText4 != "")
				Utility.ClipboardContains( compareText4, Utility.NumAttempts, absentFlag );
			if(compareText5 != "")
				Utility.ClipboardContains( compareText5, Utility.NumAttempts, absentFlag );
			if(compareText6 != "")
				Utility.ClipboardContains( compareText6, Utility.NumAttempts, absentFlag );
				
			
		}
		
		/// <summary>
		/// Проверка наличия (или отсутствия - задается параметром absentFlag) конкатенированной из всех непустых параметров строки на экране.
		/// Параметры:
		/// absentFlag = False (по умолчанию) - строки ДОЛЖНЫ БЫТЬ на экране.
		/// absentFlag = True - указанных строк НЕ должно быть на экране.
		/// compareText - compareText6 - строки, объединяемые в одну.
		/// Каждая строка может быть регулярным выражением.
		/// Строки объединяются последовательно. Пустые строки (кроме первой) игнорируются.
		/// Между объединяемыми строками не добавляются какие-либо разделители.
		/// Итоговая строка не должна быть пустой.
		/// </summary>
		/// 
		[UserCodeMethod]
		
		public static void OnScreenMerge ( bool absentFlag, string compareText, string compareText2, string compareText3,
		                                  string compareText4, string compareText5, string compareText6)
		{
			string fullTextToCompare = "";
			
			Delay.Duration(Utility.FirstDelay, false);
			Utility.CopyPuttyToClipboard();
			if(compareText != "")
				fullTextToCompare += compareText;
			if(compareText2 != "")
				fullTextToCompare += compareText2;
			if(compareText3 != "")
				fullTextToCompare += compareText3;
			if(compareText4 != "")
				fullTextToCompare += compareText4;
			if(compareText5 != "")
				fullTextToCompare += compareText5;
			if(compareText6 != "")
				fullTextToCompare += compareText6;
			
			if(fullTextToCompare != "")
				Utility.ClipboardContains( fullTextToCompare, Utility.NumAttempts, absentFlag );
			else throw new Ranorex.RanorexException ("Ошибка вызова функции OnScreenMerge! Итоговая строка для поиска не должна быть пустой!");
			
		}
		
		
		/// <summary>
		/// Ожидание появления (или исчезнования - задается параметром absentFlag) строк на экране,
		/// перечисленных в параметрах вызова функции в заданные временные параметры.
		/// Параметры:
		/// absentFlag = False (по умолчанию) - строки ДОЛЖНЫ БЫТЬ на экране.
		/// absentFlag = True - указанных строк НЕ должно быть на экране.
		/// totalDelay - максимальное время ожидания 
		/// pauseDelay - пауза между проверками
		/// compareText - compareText6 - строки для поиска, каждая из которых
		/// может быть регулярным выражением.
		/// Вхождение каждой строки ищется отдельно - порядок их следования не важен.
		/// Первая строка не должна быть пустой.
		/// </summary>
		[UserCodeMethod]
		
		public static void WaitFor ( bool absentFlag, int totalDelay, int pauseDelay, string compareText, string compareText2, string compareText3,
		                             string compareText4, string compareText5, string compareText6)
		{
			if(totalDelay <= 0 || pauseDelay <= 0 )
				throw new Ranorex.RanorexException ("Ошибка вызова функции WaitFor! Параметры общего времени и задержки не должны быть равны 0!");

			Delay.Duration(Utility.FirstDelay, false);
			Utility.CopyPuttyToClipboard();
			
			if(compareText != "")
				Utility.SmartDelay( compareText, totalDelay, pauseDelay, absentFlag );
			else throw new Ranorex.RanorexException ("Ошибка вызова функции WaitFor! Итоговая строка для поиска не должна быть пустой!");
			
			if(compareText2 != "")
				// Utility.ClipboardContains( compareText2, 1, absentFlag );
				Utility.SmartDelay( compareText2, totalDelay, pauseDelay, absentFlag );
			if(compareText3 != "")
				// Utility.ClipboardContains( compareText3, 1, absentFlag );
				Utility.SmartDelay( compareText3, totalDelay, pauseDelay, absentFlag );
			if(compareText4 != "")
				// Utility.ClipboardContains( compareText4, 1, absentFlag );
				Utility.SmartDelay( compareText4, totalDelay, pauseDelay, absentFlag );
			if(compareText5 != "")
				// Utility.ClipboardContains( compareText5, 1, absentFlag );
				Utility.SmartDelay( compareText5, totalDelay, pauseDelay, absentFlag );
			if(compareText6 != "")
				// Utility.ClipboardContains( compareText6, 1, absentFlag );
				Utility.SmartDelay( compareText6, totalDelay, pauseDelay, absentFlag );
			
		}
		
		/// <summary>
		/// Ожидание появления (или исчезнования - задается параметром absentFlag) строк на экране (объединяются в одну),
		/// перечисленных в параметрах вызова функции в заданные временные параметры.
		/// Параметры:
		/// absentFlag = False (по умолчанию) - строки ДОЛЖНЫ БЫТЬ на экране.
		/// absentFlag = True - указанных строк НЕ должно быть на экране.
		/// totalDelay - максимальное время ожидания 
		/// pauseDelay - пауза между проверками
		/// compareText - compareText6 - строки, объединяемые в одну.
		/// Каждая строка может быть регулярным выражением.
		/// Строки объединяются последовательно. Пустые строки (кроме первой) игнорируются.
		/// Между объединяемыми строками не добавляются какие-либо разделители.
		/// Итоговая строка не должна быть пустой.
		/// </summary>
		[UserCodeMethod]
		public static void WaitForMerge ( bool absentFlag, int totalDelay, int pauseDelay, string compareText, string compareText2, string compareText3,
		                             string compareText4, string compareText5, string compareText6)
		{
			
			string fullTextToCompare = "";
			
			if(totalDelay <= 0 || pauseDelay <= 0 )
				throw new Ranorex.RanorexException ("Ошибка вызова функции WaitFor! Параметры общего времени и задержки не должны быть равны 0!");

			Delay.Duration(Utility.FirstDelay, false);
			Utility.CopyPuttyToClipboard();

			if(compareText != "")
				fullTextToCompare += compareText;
			if(compareText2 != "")
				fullTextToCompare += compareText2;
			if(compareText3 != "")
				fullTextToCompare += compareText3;
			if(compareText4 != "")
				fullTextToCompare += compareText4;
			if(compareText5 != "")
				fullTextToCompare += compareText5;
			if(compareText6 != "")
				fullTextToCompare += compareText6;
			
			if(fullTextToCompare != "")
				Utility.SmartDelay( fullTextToCompare, totalDelay, pauseDelay, absentFlag );
			else throw new Ranorex.RanorexException ("Ошибка вызова функции WaitFor! Первая строка-параметр не должна быть пустой!");
			
		}
		
			
		// Репозиторий с переменной
		public static BisAutotestRepository repo = BisAutotestRepository.Instance;
		
		/// <summary>
		/// Считать значение с экрана в переменную textFromScreen
		/// textToFind - текст для поиска. len - длина строки, которая будет вырезана с экрана и сохранена в переменную репозитория
		/// varName - наименование имени переменно в репозитории BisAutotestRepository
		/// </summary>
		[UserCodeMethod]
		public static void GetFromScreen ( string textToFind, int len, string varName)
		{
			
			Delay.Duration(Utility.FirstDelay, false);
			Utility.CopyPuttyToClipboard();

			if(textToFind == "")
				throw new Ranorex.RanorexException ("Ошибка вызова функции GetFromScreen! Строка для поиска не должна быть пустой!");
			else if(len <= 0)
					throw new Ranorex.RanorexException ("Ошибка вызова функции GetFromScreen! Значение параметра len должно быть больше нуля!");
			if(repo.GetType().GetProperty(varName) == null)
				throw new Ranorex.RanorexException ("Переменная " + varName + " не существует в репозитории BisAutotestRepository!");
			// Находим нужную строку и вырезаем ее часть
			repo.GetType().GetProperty(varName).SetValue(repo, Utility.FindAndCut(textToFind, len));								
		}
			
		/// <summary>
		/// Вывести в лог переменную textFromScreen
		/// </summary>
		[UserCodeMethod]
		public static void PrintTextFromScreen (string varName)
		{
			/* FieldInfo fieldInfo = typeof(BisAutotestRepository).GetField("textFromScreen", 
			                BindingFlags.Instance | BindingFlags.NonPublic); */
			if(repo.GetType().GetProperty(varName) != null)
 				Report.Log( ReportLevel.Info, "Значение переменной " + varName + ": " +
			           (string) repo.GetType().GetProperty(varName).GetValue(repo, null));
			else throw new Ranorex.RanorexException ("Переменная " + varName + " не существует в репозитории BisAutotestRepository!");
			   
			// repo.GetType().GetProperty(varName).SetValue(repo, "KUKU");
			// Report.Log( ReportLevel.Info, "Значение переменной textFromScreen: " + repo.textFromScreen );
			
		}
		
	}

	[UserCodeCollection]
	public class PopUps
	{
		/// <summary>
		/// Добавление ожидания появления на экране опционального окна, 
		/// идентифицируемомого строками на экране,
		/// перечисленных в параметрах вызова функции.
		/// Параметры:
		/// id - строковый идентификатор окна 
		/// compareText - compareText6 - строки для поиска, каждая из которых
		/// может быть регулярным выражением.
		/// Вхождение каждой строки ищется отдельно - порядок их следования не важен.
		/// Первая строка не должна быть пустой.
		/// keySequence - комбинация клавиш, которая будет выдаваться при появлении окна
		/// </summary>
		[UserCodeMethod]
		public static void PopUpAdd ( string id, string compareText, string compareText2, string compareText3,
		                             string compareText4, string compareText5, string compareText6, string keySequence)
		{
			if(compareText != "" || id != "")
				PopUpCollection.AddOrReplace(new PopUp(id, compareText, compareText2, compareText3, compareText4,
				                                       compareText5, compareText6, keySequence));
			else throw new Ranorex.RanorexException ("Ошибка вызова функции AddPopUp! Первая и вторая строки-параметры не должны быть пустыми!");
		}
		
		/// <summary>
		/// Удаление опционального окна из списка
		/// Параметры:
		/// id - строковый идентификатор окна 
		/// </summary>
		[UserCodeMethod]
		public static void PopUpRemove ( string id )
		{
			if(id != "")
				PopUpCollection.Remove( id );
			else throw new Ranorex.RanorexException ("Ошибка вызова функции RemovePopUp! Первая строка-параметр не должна быть пустой!");
		}
		
		/// <summary>
		/// Удаление всех опциональных окон из списка
		/// </summary>
		[UserCodeMethod]
		public static void PopUpRemoveAll ( )
		{
			PopUpCollection.RemoveAll();
		}
		
		/// <summary>
		/// Проверить, нет ли на экране опциональных окон
		/// </summary>
		[UserCodeMethod]
		public static void PopUpCheck ()
		{
			Delay.Duration(Utility.FirstDelay, false);
			Utility.CopyPuttyToClipboardStep();
			Utility.CheckPopUp();
		}
		
		
	}

	
	
	[UserCodeCollection]
	public class WinSys
	{
		
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);
		
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);
		
		private static uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
		private static int HWND_BROADCAST = 0xffff;
		private static string ru_RU = "00000419";
		private static string en_US = "00000409";
		private static uint KLF_ACTIVATE = 1;

		
		/// <summary>
		/// Изменение раскладки клавиатуры 
		/// Параметры:
		/// langCode - код языка, на который надо переключить раскладку. rus - русская, eng - английская
		/// </summary>
		[UserCodeMethod]
		// Изменение языка системы
		public static void ChangeLayout(string langCode)
		{
			string langCodeString = en_US;
		 	
			if(string.Equals(langCode, "rus" ))
				langCodeString = ru_RU;
			PostMessage(HWND_BROADCAST,WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero ,LoadKeyboardLayout(langCodeString,KLF_ACTIVATE));
			Delay.Milliseconds(300);
	        Report.Log(ReportLevel.Info, "Раскладка клавиатуры изменена на: " + langCode);
	            	
		}
		
	}
	
	[UserCodeCollection]
	public class FileSystem
	{
		/// <summary>
		/// Функция поиска строк-параметров в содержимом текстового файла.
		/// Для корректной работы с русским текстом файл должен иметь кодировку UTF-8.
		/// absentFlag = False (по умолчанию) - строки ДОЛЖНЫ БЫТЬ в файле.
		/// absentFlag = True - указанных строк НЕ должно быть в файле.
		/// path - путь к файлу (может быт пустым), fileName - имя файла.
		/// codePage - кодовая страница, например, windows-1251
		/// compareText - compareText6 - строки, наличие которых нужно проверить в файле.
		/// Первая строка-параметр не должна быть пустой.
		/// </summary>
		[UserCodeMethod]
		public static void InFile (bool absentFlag, string path, string fileName, string codePage, string compareText, string compareText2, string compareText3,
		                           string compareText4, string compareText5, string compareText6)
		{
			string fileNameWithPath, fileText;

			// Составляем полное имя файла с путем к нему
			if (path != "")
				fileNameWithPath = path + "\\" + fileName;
			else fileNameWithPath = fileName;
			
			// Проверяем физическое наличие файла
			if(!File.Exists(fileNameWithPath))
			{
				throw new Ranorex.RanorexException("Файл \"" + fileNameWithPath + "\" не существует!");
			}
			
			// Читаем файл в строку
			fileText = File.ReadAllText(fileNameWithPath, Encoding.GetEncoding(codePage));
			
			if(compareText != "")
				Utility.FileContains( fileNameWithPath, fileText, compareText, absentFlag );
			else throw new Ranorex.RanorexException ("Ошибка вызова функции InFile! Первая строка-параметр не должна быть пустой!");
			
			if(compareText2 != "")
				Utility.FileContains( fileNameWithPath, fileText, compareText2, absentFlag );
			if(compareText3 != "")
				Utility.FileContains( fileNameWithPath, fileText, compareText3, absentFlag );
			if(compareText4 != "")
				Utility.FileContains( fileNameWithPath, fileText, compareText4, absentFlag );
			if(compareText5 != "")
				Utility.FileContains( fileNameWithPath, fileText, compareText5, absentFlag );
			if(compareText6 != "")
				Utility.FileContains( fileNameWithPath, fileText, compareText6, absentFlag );
			
		}
		
		/// <summary>
		/// Функция поиска строки (получаемой путем объединения строк-параметров) 
		/// в содержимом текстового файла.
		/// Для корректной работы с русским текстом файл должен иметь кодировку UTF-8.
		/// absentFlag = False (по умолчанию) - строки ДОЛЖНЫ БЫТЬ в файле.
		/// absentFlag = True - указанных строк НЕ должно быть в файле.
		/// path - путь к файлу (может быт пустым), fileName - имя файла.
		/// codePage - кодовая страница, например, windows-1251
		/// compareText - compareText6 - строки, наличие которых нужно проверить в файле.
		/// Строки объединяются последовательно. Пустые строки (кроме первой) игнорируются.
		/// Между объединяемыми строками не добавляются какие-либо разделители.
		/// Итоговая строка не должна быть пустой.
		/// </summary>
		[UserCodeMethod]
		public static void InFileMerge (bool absentFlag, string path, string fileName, string codePage, string compareText, string compareText2, string compareText3,
		                           string compareText4, string compareText5, string compareText6)
		{
			string fileNameWithPath, fileText;
			string fullTextToCompare = "";

			// Составляем полное имя файла с путем к нему
			if (path != "")
				fileNameWithPath = path + "\\" + fileName;
			else fileNameWithPath = fileName;
			
			// Проверяем физическое наличие файла
			if(!File.Exists(fileNameWithPath))
			{
				throw new Ranorex.RanorexException("Файл \"" + fileNameWithPath + "\" не существует!");
			}
			
			// Читаем файл в строку
			fileText = File.ReadAllText(fileNameWithPath, Encoding.GetEncoding(codePage));
			
			
			if(compareText != "")
				fullTextToCompare += compareText;
			if(compareText2 != "")
				fullTextToCompare += compareText2;
			if(compareText3 != "")
				fullTextToCompare += compareText3;
			if(compareText4 != "")
				fullTextToCompare += compareText4;
			if(compareText5 != "")
				fullTextToCompare += compareText5;
			if(compareText6 != "")
				fullTextToCompare += compareText6;
			
			if(fullTextToCompare != "")
				Utility.FileContains( fileNameWithPath, fileText, fullTextToCompare, absentFlag );
			else throw new Ranorex.RanorexException ("Ошибка вызова функции InFileMerge! Итоговая строка для поиска не должна быть пустой!");
			
		}
		
		
		/// <summary>
		/// Функция побайтового сравнения двух файлов любого формата. 
		/// path1 - путь к первому файлу (может быт пустым), fileName1 - имя первого файла.
		/// path2 - путь к второму файлу (может быт пустым), fileName2 - имя второго файла.
		/// </summary>
		[UserCodeMethod]
		public static void CompareFiles( string path1, string fileName1, string path2, string fileName2 )
        {
        
			// Запускаем универсальную функцию сравнения
			// Тип сравнения - побайтовое сравнение файлов (делегат CompareFileBytes)
			
        	Utility.CompareFilesUniversal(path1, fileName1, path2, fileName2, 
        	                              Utility.CompareFileBytes);
        }
		
		
		/// <summary>
		/// Функция сравнения двух DBF файлов. Игнорируются первые 32 байта управляющей информации 
		/// path1 - путь к первому файлу (может быт пустым), fileName1 - имя первого файла.
		/// path2 - путь к второму файлу (может быт пустым), fileName2 - имя второго файла.
		/// </summary>
		[UserCodeMethod]
		public static void CompareDBFs( string path1, string fileName1, string path2, string fileName2 )
        {
        
			// Запускаем универсальную функцию сравнения
			// Тип сравнения - сравнение файлов DBF (делегат CompareFileDBF)
			
        	Utility.CompareFilesUniversal(path1, fileName1, path2, fileName2, 
        	                              Utility.CompareFileDBF);
        }
		
		
	}
	
	
	[UserCodeCollection]
	public class RemoteControl
	{
		/// <summary>
		/// Получение файла с удаленного сервера.
		/// Параметры:
		/// winScpPath - в этом параметре указывается полный путь к программе WinSCP 
		/// (Для работы функции требуется установленный WinSCP - https://winscp.net/.
		/// Пример: C:/Program Files/WinSCP/winscp.exe).
		/// scpSessionName - название сессии в WinSCP (В WinSCP должна быть настроена сессия
		/// с информацией об удаленном сервере, включая логин и пароль, опционально - путь к удаленному каталогу). 
		/// remotePath - путь к файлу на удаленном сервере (может быть пустым), remoteFileName - имя файла на удаленном сервере (может быть маской).
		/// localPath - путь к файлу на локальном сервере (не может быть пустым), localFileName - имя файла на локальном сервере.
		/// </summary>
		[UserCodeMethod]
		public static void GetFile (string winScpPath, string scpSessionName, string remotePath, string remoteFileName, 
		                            string localPath, string localFileName)
		{
			
			string fullLocalFileName = localFileName; 
			
			// Составляем полное имя файла
			if(localPath != "")
        		fullLocalFileName = localPath + "\\" + localFileName;
			else throw new Ranorex.RanorexException ("Ошибка вызова функции GetFile! Путь к локальному файлу не может быть пустым!" );
        	
        	// Проверяем физическое наличие локального файла и удаляем его, если он существует
			if(File.Exists(fullLocalFileName))
		    {
				try {
					File.Delete(fullLocalFileName);
				}
				catch {
					throw new Ranorex.RanorexException ("Ошибка вызова функции GetFile! Не могу удалить файл: " +
						fullLocalFileName );
				}
		    }
			
			// Формируем процесс для запуска winscp
	        ProcessStartInfo startInfo = new ProcessStartInfo();
	        startInfo.CreateNoWindow = false;
	        startInfo.UseShellExecute = false;
	        startInfo.FileName = winScpPath;
	        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
	        startInfo.Arguments = "/command \"open " + scpSessionName + "\" ";
	        // Удаленный путь может быть пустым (сохраненным в сессии WinSCP)
	        if(remotePath != "")
	        	startInfo.Arguments += "\"cd " + remotePath + "\" ";
	        startInfo.Arguments += "\"get " + remoteFileName + " " + fullLocalFileName + "\" " + "\"exit\"";

	        try
		        {
		            // Запускаем процесс и ждем его окончания
		            using (Process exeProcess = Process.Start(startInfo))
		            {
		                exeProcess.WaitForExit();
		            }
		        }
	        catch
	        {
	            throw new Ranorex.RanorexException ("Ошибка вызова функции GetFile c аргументом: " +
					startInfo.Arguments);
	        }
	        
	        if(!File.Exists(fullLocalFileName))
		    {
	        	// Если файл не получен - выбрасываем ошибку
	        	Ranorex.Validate.IsTrue (false, "Ошибка вызова функции GetFile! Файл: " +
					fullLocalFileName + " не получен!");
	        	
	        } else {
	        	Ranorex.Validate.IsTrue(true, "Получен файл \'" + fullLocalFileName  + "\'" );
	        }
			
		}
		
		/// <summary>
		/// Удаление файла на удаленном сервере.
		/// Параметры:
		/// winScpPath - в этом параметре указывается полный путь к программе WinSCP 
		/// (Для работы функции требуется установленный WinSCP - https://winscp.net/.
		/// Пример: C:/Program Files/WinSCP/winscp.exe).
		/// scpSessionName - название сессии в WinSCP (В WinSCP должна быть настроена сессия
		/// с информацией об удаленном сервере, включая логин и пароль, опционально - путь к удаленному каталогу). 
		/// remotePath - путь к файлу на удаленном сервере (может быть пустым), remoteFileName - имя файла на удаленном сервере (может быть маской).
		/// </summary>
		[UserCodeMethod]
		public static void DeleteFile (string winScpPath, string scpSessionName, string remotePath, string remoteFileName)
		                            
		{
			// Формируем процесс для запуска winscp
	        ProcessStartInfo startInfo = new ProcessStartInfo();
	        startInfo.CreateNoWindow = false;
	        startInfo.UseShellExecute = false;
	        startInfo.FileName = winScpPath;
	        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
	        startInfo.Arguments = "/command \"open " + scpSessionName + "\" ";
	        // Удаленный путь может быть пустым (сохраненным в сессии WinSCP)
	        if(remotePath != "")
	        	startInfo.Arguments += "\"cd " + remotePath + "\" ";
	        startInfo.Arguments += "\"rm " + remoteFileName + "\" " + "\"exit\"";

	        try
		        {
		            // Запускаем процесс и ждем его окончания
		            using (Process exeProcess = Process.Start(startInfo))
		            {
		                exeProcess.WaitForExit();
		            }
		        }
	        catch
	        {
	            throw new Ranorex.RanorexException ("Ошибка вызова функции DeleteFile c аргументом: " +
					startInfo.Arguments);
	        }
	        
	        Ranorex.Validate.IsTrue(true, "Вызвана функция DeleteFile. Файл: \'" + remoteFileName  + "\'" );
			
		}
		
	
	}
	

	// Класс для pop-ups
	public class PopUp
	{
		public string id { get; set; }
		public string compareText, compareText2, compareText3, compareText4, compareText5, compareText6; 
		public string keySequence;
		
		// Конструктор. При пустом id идентифицирует PopUp по первой строке
		public PopUp ( string id, string compareText, string compareText2, string compareText3,
		      string compareText4, string compareText5, string compareText6, string keySequence)
		{
			if(id == "")
				this.id = this.compareText;
			else this.id = id;
			this.compareText = compareText;
			this.compareText2 = compareText2;
			this.compareText3 = compareText3;
			this.compareText4 = compareText4;
			this.compareText5 = compareText5;
			this.compareText6 = compareText6;
			this.keySequence = keySequence;
			
		}
		
		// Процедура сравнения двух PopUp (исключаются из сравнения id и keySequence)
		public bool EqualTo(PopUp obj)
        {
			bool retVal = false;
			
			if (this.compareText.Equals(obj.compareText) &&
			    this.compareText2.Equals(obj.compareText2) &&
			    this.compareText3.Equals(obj.compareText3) &&
			    this.compareText4.Equals(obj.compareText4) &&
			    this.compareText5.Equals(obj.compareText5) &&
			    this.compareText6.Equals(obj.compareText6))
                retVal = true;
            
			return( retVal );
        }
		
	}
	
	// Коллекция PopUp
	public static class PopUpCollection
	{
		// Список активных PopUp
		public static List<PopUp> popUpList;
		
		// Создаем пустой список PopUp
		static PopUpCollection()
		{
			popUpList = new List<PopUp>();
		}
		
		// Добавить или заменить PopUp (если существует)
		public static void AddOrReplace(PopUp obj)
		{
			// Ищем PopUp с таким же идентификатором
			// Если найден - удаляем его 
			Remove(obj.id);
			// Добавляем объект в список
			popUpList.Add(obj);
		}
		
		// Удалить PopUp по ключу (id)
		public static void Remove(string id)
		{
			// Ищем PopUp с таким же идентификатором
			PopUp p = popUpList.Find(x => x.id.Equals(id));
			
			// Если найден - удаляем его 
			if( p != null )
				popUpList.Remove(p);
		}
		
		// Удалить все PopUps
		public static void RemoveAll()
		{
			popUpList.Clear();
		}
		
	}
	
	// Класс с набором статических хелперов
	public class Utility
	{

		// --------   Определение констант ----------------
		// Задержка перед переключением в путти
		public const int FirstDelay = 300;
		// Задержка после копирования в клипбоард
		public const int SecondDelay = 300;
		// Задержка в случае возникновения ошибки
		public const int ErrDelay = 5000;
		// Время движения мыши
		public const int MoveTime = 0;
		// Количество повторов в случае возникновения ошибки
		public const int NumAttempts = 5;

		// --------   Конец определение констант ----------
		
		
		// Репозиторий с данными для съемки экрана путти
		public static BisAutotestRepository repo = BisAutotestRepository.Instance;

		// Копирование данных из путти в клипбоард и проверка появления опциональных окон
		public static void CopyPuttyToClipboard()
		{
			CopyPuttyToClipboardStep();
			// проверяем наличие опциональных окон
			if(CheckPopUp())
				CopyPuttyToClipboardStep();
		}
		
		// Копирование данных из путти в клипбоард
		public static void CopyPuttyToClipboardStep()
		{
			bool rpt = false;
			
			do
			{
				rpt = false;
				try
				{
					repo.AnyPuTTY.Система.MoveTo(MoveTime);
					Delay.Duration(300, false);
					repo.AnyPuTTY.Система.Click("3;3", MoveTime);
					Delay.Duration(100, false);
					repo.Putty.CopyAllToClipboard.MoveTo(MoveTime);
					Delay.Duration(300, false);
					repo.Putty.CopyAllToClipboard.Click("86;7", MoveTime);
				} 
				catch (RanorexException e)
				{
					rpt = true;
					Report.Log(ReportLevel.Info, e.Message);
				}
			} 
			while(rpt);
			Delay.Duration(SecondDelay, false);
			Report.Log(ReportLevel.Info, "Mouse", "Putty - CopyAllToClipboard", repo.Putty.CopyAllToClipboardInfo);
			
		}
		
		// Проверить, нет ли PopUp в списке и предпринять нужные действия
		// В параметре obj игнорируются поля id и keySequence
		public static bool CheckPopUp()
		{
			bool atLeastOnce = false;
			
			// Ищем PopUp с таким же идентификатором
			foreach (PopUp p in PopUpCollection.popUpList) 
			{
				if(FindInClipboard(p.compareText) == 1 &&
				   (p.compareText2 == "" || FindInClipboard(p.compareText2) == 1) &&
				   (p.compareText3 == "" || FindInClipboard(p.compareText3) == 1) &&
				   (p.compareText4 == "" || FindInClipboard(p.compareText4) == 1) &&
				   (p.compareText5 == "" || FindInClipboard(p.compareText5) == 1) &&
				   (p.compareText6 == "" || FindInClipboard(p.compareText6) == 1))
					{
					Report.Log(ReportLevel.Info, "Обнаружен PopUp с id: " + p.id);
	            	repo.AnyPuTTY.Self.PressKeys(p.keySequence, 600);
	            	Delay.Milliseconds(300);
	            	Report.Log(ReportLevel.Info, "Нажата последовательность клавиш: " + p.keySequence);
	            	atLeastOnce = true;
	            	break;
					}
				
			}
			
			return( atLeastOnce );
		}
		
		
		// Проверка наличия текста из compareText в clipboardText
		// Возвращаемое значение - true - если найден, false - если не найден
		public static bool IsMatch( string clipboardText, string compareText)
		{
			bool checkResult = false;
			
			// Ищем регулярное выражение
			Regex regexLocal = new Regex(compareText);
			MatchCollection matchLocal = regexLocal.Matches( clipboardText );
			
			// Проверяем, есть ли искомый текст в клипбоард
			if( matchLocal.Count > 0)
			{
				checkResult = true;
			}
			
			return checkResult;
		}
		
		// Проверка наличия строки-параметра (может быть регулярным выражением) в клипборде
		// Возвращаемые значения
		// 1 - строка найдена, 0 - пустой клипборд, -1 - строка не найдена
		public static int FindInClipboard( string compareText )
		{
			int checkResult = -1;
			
			// Проверяем, есть ли текст в клипбоард
			if ( System.Windows.Forms.Clipboard.ContainsText ())
			{
				// Получаем текст из клипбоарда и ищем вхождение в него строки
				if(IsMatch( System.Windows.Forms.Clipboard.GetText (), compareText ))
					checkResult = 1;
			}
			else checkResult = 0;
			
			return( checkResult );
		}
		
		// Найти в клипбоарде вхождение строки compareText и вырезать строку длиной len символов,
		// следующую за найденным фрагментом. 
		// В случае успеха - вернуть вырезанную строку, в случае, если строка не найдена - вернуть Null
		// В возвращаемой строке обрезаются пробелы в начале и конце
		public static string FindAndCut( string compareText, int len )
		{
			// Возвращаемое значение
			string checkResult = null;
			
			// Проверяем, есть ли текст в клипбоард
			if ( System.Windows.Forms.Clipboard.ContainsText ())
			{
				// Конструируем регулярное выражение
				Regex rg = new Regex(compareText);
				// Текст из клипбоарда
				string clipText = System.Windows.Forms.Clipboard.GetText ();
				// Получаем текст из клипбоарда и ищем вхождение в него строки
				Match match = rg.Match( clipText );
				// Начальная точка в compareText, откуда будет вырезаться текст
				int startPoint = match.Index + match.Length;
				// Если строка найдена и после нее есть еще достаточно символов
 				if(match.Success && clipText.Length > startPoint + len  )
				{
					checkResult = clipText.Substring(startPoint, len).Trim();
				}
			}
			
			// Сообщение для лога Ranorex
			string logMsg = "Строка \"" + compareText + "\" ";
			if(checkResult == null)
			{
				logMsg = logMsg + " не найдена или недостаточно места для получения новой строки! Переменная имеет значение null";
				Ranorex.Validate.IsTrue(false, logMsg);
			}
			else{
				logMsg = logMsg + " найдена. Значение в переменную сохранено";
				Ranorex.Validate.IsTrue(true, logMsg);
			}
			
					
		
			return( checkResult );
		}
		
		
		// Проверка того, что строки comparetText-compareText6 находятся в клипбоарде с защитой от притормаживания
		// системы (добавленное количество итераций - iterations)
		// Функция также используется для проверки отсутствия искомого (когда флаг absentFlag имеет
		// значение true)
		public static void ClipboardContains6 ( string compareText, string compareText2, string compareText3,
		                             string compareText4, string compareText5, string compareText6, bool absentFlag )
		{
			
			// Счетчик итераций
			int iterations = Utility.NumAttempts;
			
			// Значение-результат
			int retResult;
			
			// Счетчик непустых строк
			int numStrings = 1;
			
			// Единая строка
			string wholeStr = "";
			
			// Запускаем проверку
			do
			{
				retResult = FindInClipboard( compareText );
				if(retResult == 0)
					throw new Ranorex.RanorexException ("Буфер обмена пустой");
				else wholeStr = compareText;
						
				if(compareText2 != "")
				{
					retResult += FindInClipboard( compareText2 );
					numStrings++;
					wholeStr += ", " + compareText2;
				}
				if(compareText3 != "")
				{
					retResult += FindInClipboard( compareText3 );
					numStrings++;
					wholeStr += ", " + compareText3;
				}
				if(compareText4 != "")
				{
					retResult += FindInClipboard( compareText4 );
					numStrings++;
					wholeStr += ", " + compareText4;
				}
				if(compareText5 != "")
				{
					retResult += FindInClipboard( compareText5 );
					numStrings++;
					wholeStr += ", " + compareText5;
				}
				if(compareText6 != "")
				{
					retResult += FindInClipboard( compareText6 );
					numStrings++;
					wholeStr += ", " + compareText6;
				}
			
				
				iterations--;
				if(iterations > 0 && ((retResult != numStrings && !absentFlag) || 
				                      (retResult != -numStrings && absentFlag)))
				{
					// Включаем дополнительное ожидание
					Delay.Duration(ErrDelay, false);
					CopyPuttyToClipboard();
				}
			}
			while( iterations > 0 && ((retResult != numStrings && !absentFlag) || 
				                      (retResult != -numStrings && absentFlag)));
			
			if(!absentFlag)
			{
				// Ищем наличие
				if(retResult == numStrings)
					Ranorex.Validate.IsTrue(true, "На экране найдены все строки из списка \"" + wholeStr + "\"");
				else Ranorex.Validate.IsTrue(false, "ОШИБКА! На экране не найдена одна или более строк из списка \"" + wholeStr + "\"" );
			}
			else{
				// Ищем отсутствие
				if(retResult == -numStrings)
					Ranorex.Validate.IsTrue(true, "На экране не найдено ни одной строки из списка \"" + wholeStr + "\"" );
				else Ranorex.Validate.IsTrue(false, "ОШИБКА! На экране найдена одна или более строк из списка \"" + wholeStr  + "\"" );
			}
			
		}
		
		
		// Проверка того, что строка comparetText находится в клипбоарде с защитой от притормаживания
		// системы (добавленное количество итераций - iterations)
		// Функция также используется для проверки отсутствия искомого (когда флаг absentFlag имеет
		// значение true)
		public static void ClipboardContains ( string compareText, int iterations, bool absentFlag )
		{

			// Значение-результат
			int retResult;
			
			// Запускаем проверку
			do
			{
				retResult = FindInClipboard( compareText );
				iterations--;
				if(iterations > 0 && ((retResult == -1 && !absentFlag) || 
				                      (retResult == 1 && absentFlag)))
				{
					// Включаем дополнительное ожидание
					Delay.Duration(ErrDelay, false);
					CopyPuttyToClipboard();
				}
			}
			while( iterations > 0 && ((retResult == -1 && !absentFlag) || 
				                      (retResult == 1 && absentFlag)));
			
			switch( retResult )
			{
				case -1:
					if(!absentFlag)
						Ranorex.Validate.IsTrue(false, "ОШИБКА! На экране не найдена строка \"" + compareText + "\"" );
					else Ranorex.Validate.IsTrue(true, "На экране не найдена строка \"" + compareText + "\"" );
					break;
				case 1:
					if(!absentFlag)
						Ranorex.Validate.IsTrue(true, "На экране найдена строка \"" + compareText + "\"");
					else Ranorex.Validate.IsTrue(false, "ОШИБКА! На экране найдена строка \"" + compareText  + "\"" );
					break;
				case 0:
					throw new Ranorex.RanorexException ("Буфер обмена пустой");
			}
		}
		
		
		
		// Ожидание появление (отсутствия) необходимой информации на экране 
		// Функция также используется для проверки отсутствия искомого (когда флаг absentFlag имеет
		// значение true)
		// totalDelay - задержка (в секундах)
		// pauseDelay - задержка (в секундах)
		public static void SmartDelay ( string compareText, int totalDelay, int pauseDelay, bool absentFlag )
		{

			// Значение-результат
			int retResult;
			int iterations;
			
			// Запускаем проверку
			iterations = Convert.ToInt32(totalDelay / pauseDelay);
			
			do
			{
				retResult = FindInClipboard( compareText );
				iterations--;
				if(iterations > 0 && ((retResult == -1 && !absentFlag) || 
				                      (retResult == 1 && absentFlag)))
				{
					// Включаем дополнительное ожидание
					Delay.Duration(pauseDelay * 1000, false);
					CopyPuttyToClipboard();
				}
			}
			while( iterations > 0 && ((retResult == -1 && !absentFlag) || 
				                      (retResult == 1 && absentFlag)));
			
			switch( retResult )
			{
				case -1:
					if(!absentFlag)
						Ranorex.Validate.IsTrue(false, "ОШИБКА! На экране не появилась строка \"" + compareText + "\"" );
					else Ranorex.Validate.IsTrue(true, "С экрана исчезла строка \"" + compareText + "\"" );
					break;
				case 1:
					if(!absentFlag)
						Ranorex.Validate.IsTrue(true, "На экране появилась строка \"" + compareText + "\"");
					else Ranorex.Validate.IsTrue(false, "ОШИБКА! С экрана не исчезла строка \"" + compareText  + "\"" );
					break;
				case 0:
					throw new Ranorex.RanorexException ("Буфер обмена пустой");
			}
		}
		
		// Проверка наличия строки в содержимом файла
		// Функция также используется для проверки отсутствия искомого (когда флаг absentFlag имеет
		// значение true)
		public static void FileContains ( string fileName, string fileText, string compareText, bool absentFlag ) 
		{
			if(IsMatch(fileText, compareText))
			{
				if(!absentFlag)
					// Проверка успешна
					Ranorex.Validate.IsTrue(true, "В файле \'" + fileName  + "\' содержится строка \"" + compareText +"\"" );
				else Ranorex.Validate.IsTrue(false, "Ошибка!!! В файле \'" + fileName  + "\' содержится строка \"" + compareText +"\"" );
			}
			else{
				if(!absentFlag)
					// Текст не найден
					Ranorex.Validate.IsTrue(false, "Ошибка!!! В файле \'" + fileName  + "\' нет строки \"" + compareText +"\"" );
				else Ranorex.Validate.IsTrue(true, "В файле \'" + fileName  + "\' нет строки \"" + compareText +"\"" );
			}
		}
		
		
		// Побайтовое сравнение файлов, пути к которым указаны в параметрах
		// Возвращает true, если файлы идентичны, false - если нет
        public static bool CompareFileBytes(string fileName1, string fileName2)
		{
		    int file1byte = 0;
	        int file2byte = 0;
	
	        // Открываем файлы с использованием using
	        using (FileStream fileStream1 = new FileStream(fileName1, FileMode.Open),
	                          fileStream2 = new FileStream(fileName2, FileMode.Open))
	        {
	            
	        	if (fileStream1.Length == fileStream2.Length)
	        	{
		        	// Побайтово сравниваем файлы
		            do
		            {
		                file1byte = fileStream1.ReadByte();
		                file2byte = fileStream2.ReadByte();
		            }
		            while ((file1byte == file2byte) && (file1byte != -1));
	        	}
	        	else {
	        		return false;
	        	}
	        }
	
	        return ((file1byte - file2byte) == 0);
		    
		}
        
        
        // Первый вариант - побайтовое сравнение файлов DBF (вырезаем первые 32 байта - заголовок)
        public static bool CompareFileDBF(string fileName1, string fileName2)
		{
	        int file1byte = 0;
	        int file2byte = 0;
	        int bytesCount = 0;
	
			// Используем using для автоматического закрытия потоков
	        using (FileStream fileStream1 = new FileStream(fileName1, FileMode.Open, FileAccess.Read, FileShare.Read),
	                          fileStream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read, FileShare.Read))
	        {
	            
	        	if (fileStream1.Length == fileStream2.Length)
        		{
		            do
		            {
		                file1byte = fileStream1.ReadByte();
		                file2byte = fileStream2.ReadByte();
		                bytesCount++;
		            }
		        	// Исключаем первый 32 байта с управляющей (переменной) информацией
		            while ((file1byte == file2byte || bytesCount < 32) && (file1byte != -1));
	        	}
	        	else
			    {
			        return false;
			    }
	        }
	
	        return ((file1byte - file2byte) == 0);
		    
		    
		}
        
		// Сравнение двух файлов 
		// Используемая функция для сравнения передается в делегате compareFileFunc		
        public static void CompareFilesUniversal( string path1, string fileName1,
                                                 string path2, string fileName2, 
                                                 Func<string, string, bool> compareFileFunc)
        {
        	string file1, file2;
        	bool retResult = true;
        	string retMsg = "";
        	
        	if(path1 != "")
        		file1 = path1 + "\\" + fileName1;
        	else file1 = fileName1;
        	
        	if(path2 != "")
        		file2 = path2 + "\\" + fileName2;
        	else file2 = fileName2;
        	
      	
        	// Проверяем физическое наличие файлов
			if(!File.Exists(file1))
		    {
			   	retResult = false;
			   	retMsg = "Файл \'" + file1 + "\' не существует!";
		    }
			
			if(!File.Exists(file2))
		    {
			   	retResult = false;
			   	retMsg = "Файл \'" + file2 + "\' не существует!";
		    }
			      
        	
        	// Запускаем проверку
        	if(retResult)
        	{
        		// Вызываем переданную функцию для сравнения
        		retResult = compareFileFunc(file1, file2 );
	        	if(retResult)
	        	{
	        		retMsg = "Файлы \'" + file1 + "\' и \'" + file2 + "\' идентичны";  
	        	} else {
	        		retMsg = "Файлы \'" + file1 + "\' and \'" + file2 + "\' отличаются";
	        	}
        	}
        	
        	
        	// Формируем лог-сообщение
        	Ranorex.Validate.IsTrue(retResult, retMsg );
        	
        }

	}
}
