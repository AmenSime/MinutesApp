using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Amen_WpfApp4
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }



        
        public void checkFile()
        {
            /* var doc = DocumentModel.Load(".docx");

             foreach (var section in doc.Sections)
             {
                 HeaderFooter headerFooter;
                 List<string> texts;

                 // Read first page header's text.
                 headerFooter = section.HeadersFooters[HeaderFooterType.HeaderFirst];
                 if (headerFooter != null)
                     texts.Add(headerFooter.Content.ToString());

                 // Read even pages header's text.
                 headerFooter = section.HeadersFooters[HeaderFooterType.HeaderEven];
                 if (headerFooter != null)
                     texts.Add(headerFooter.Content.ToString());

                 // Read default header's text.
                 headerFooter = section.HeadersFooters[HeaderFooterType.HeaderDefault];
                 if (headerFooter != null)
                     texts.Add(headerFooter.Content.ToString());

                 // Read section's text.
                 texts.Add(section.Content.ToString());

                 // Read first page footer's text.
                 headerFooter = section.HeadersFooters[HeaderFooterType.FooterFirst];
                 if (headerFooter != null)
                     texts.Add(headerFooter.Content.ToString());

                 // Read even pages footer's text.
                 headerFooter = section.HeadersFooters[HeaderFooterType.FooterEven];
                 if (headerFooter != null)
                     texts.Add(headerFooter.Content.ToString());

                 // Read default footer's text.
                 headerFooter = section.HeadersFooters[HeaderFooterType.FooterDefault];
                 if (headerFooter != null)
                     texts.Add(headerFooter.Content.ToString());
             }
         }*/
        }
}

}
