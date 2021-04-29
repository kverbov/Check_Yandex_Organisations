using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using TestProject1;

namespace CheckAddr
{
    /// <summary>
    /// Сводное описание для CheckPos
    /// </summary>
    [CodedUITest]
    public class CheckPos
    {
        public CheckPos()
        {
        }

        
        [TestMethod]
        public void CodedUITestMethod1()
        {
            
            // считываем адреса фирмы из справочника
            string[] addrList =  MyTest.GetAddr();
            
            // сопоставление метро к адресу
            string[] metroList = MyTest.GetMetroName(addrList);

            // проверка живых адресов 
            string [] nullAddr = MyTest.CheckPosByAddr(metroList);

            // запись в файл процента живых точек и мертвых адресов 
            MyTest.Export(nullAddr);
            
        }

        #region Дополнительные атрибуты тестирования

        // При написании тестов можно использовать следующие дополнительные атрибуты:

        ////TestInitialize используется для выполнения кода перед запуском каждого теста 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Чтобы создать код для этого теста, выберите в контекстном меню команду "Сформировать код для кодированного теста ИП", а затем выберите один из пунктов меню.
        //    // Дополнительные сведения по сформированному коду см. по ссылке http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Чтобы создать код для этого теста, выберите в контекстном меню команду "Сформировать код для кодированного теста ИП", а затем выберите один из пунктов меню.
        //    // Дополнительные сведения по сформированному коду см. по ссылке http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public MyTest MyTest
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new MyTest();
                }

                return this.map;
            }
        }

        private MyTest map;
    }
}
