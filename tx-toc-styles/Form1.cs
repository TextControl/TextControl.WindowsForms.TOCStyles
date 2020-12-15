using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace tx_toc_styles {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

      private void Form1_Load(object sender, EventArgs e) {

         // load sample document
			textControl1.Load("article.tx", TXTextControl.StreamType.InternalUnicodeFormat);

         // create a new RibbonItem
         RibbonButton rbMyButton = new RibbonButton() {
            Text = "Convert to Style",
            LargeIcon = imageList1.Images[0]
         };

         // attach Click event
			rbMyButton.Click += RbMyButton_Click; ;

         // create a new RibbonGroup
         HorizontalRibbonGroup rgMyRibbonGroup = new HorizontalRibbonGroup() {
            Text = "Styles",
            ShowSeperator = true
         };

         // add the RibbonItem to the RibbonGroup
         rgMyRibbonGroup.RibbonItems.Add(rbMyButton);
         ribbonReferencesTab1.RibbonGroups.Add(rgMyRibbonGroup);
      }

		private void RbMyButton_Click(object sender, EventArgs e) {
         // create a style
         var styleName = textControl1.CreateStyleFromSelection();

         // apply style
         textControl1.CompareAndApplyStyle(styleName);
		}


   }
}
