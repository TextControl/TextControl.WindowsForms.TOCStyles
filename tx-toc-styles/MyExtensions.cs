using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tx_toc_styles {
   public static class MyExtensions {
      public static string CreateStyleFromSelection(this TXTextControl.TextControl textControl) {

         // get current input position
         var iParStart = textControl.Paragraphs.GetItem(
            textControl.InputPosition.TextPosition).Start;
         textControl.Select(iParStart, 0);

         // create a new paragraph style based on current formatting
         TXTextControl.ParagraphStyle parStyle = 
            new TXTextControl.ParagraphStyle("custom_" + Guid.NewGuid().ToString());

         // set style
         parStyle.Baseline = textControl.Selection.Baseline;
         parStyle.Bold = textControl.Selection.Bold;
         parStyle.FontName = textControl.Selection.FontName;
         parStyle.FontSize = textControl.Selection.FontSize;
         parStyle.ForeColor = textControl.Selection.ForeColor;
         parStyle.Italic = textControl.Selection.Italic;
         parStyle.Strikeout = textControl.Selection.Strikeout;
         parStyle.TextBackColor = textControl.Selection.TextBackColor;
         parStyle.Underline = textControl.Selection.Underline;

         // add style to TextControl
         textControl.ParagraphStyles.Add(parStyle);

         // return the style name
         return parStyle.Name;
      }

      public static void CompareAndApplyStyle(this TXTextControl.TextControl textControl, string paragraphStyleName) {

         // store input position
         var iStartPos = textControl.Selection.Start;

         // retrieve the style based on a name
         TXTextControl.ParagraphStyle style = textControl.ParagraphStyles.GetItem(paragraphStyleName);

         // loop through all paragraphs to check whether the style
         // matches the paragraph style
         foreach (TXTextControl.Paragraph par in textControl.Paragraphs) {

            textControl.Select(par.Start, 0);
            var selection = textControl.Selection;

            if (selection.Baseline == style.Baseline &&
               selection.Bold == style.Bold &&
               selection.FontName == style.FontName &&
               selection.FontSize == style.FontSize &&
               selection.ForeColor == style.ForeColor &&
               selection.Italic == style.Italic &&
               selection.Strikeout == style.Strikeout &&
               selection.Underline == style.Underline) {

               // style matches - apply style
               par.FormattingStyle = paragraphStyleName;
            }

         }

         // reset input position
         textControl.Selection.Start = iStartPos;
      }
   }

}
