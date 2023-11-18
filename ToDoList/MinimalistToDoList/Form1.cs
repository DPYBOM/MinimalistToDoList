using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MinimalistToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.KeyDown += richTextBox1_KeyDown;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Ctrl + B is pressed
            if (e.Control && e.KeyCode == Keys.B)
            {
                // Toggle bold for the selected text or the text to be inserted
                ToggleBold();

                // Prevent further processing of the key event
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.I)
            {
                ToggleItalic();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                ToggleUnderline();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.OemCloseBrackets)
            {
                ChangeFontSizeOfSelectedText(2);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.OemOpenBrackets)
            {
                ChangeFontSizeOfSelectedText(-2);
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    ChangeOverallFont(fontDialog.Font);
                    e.SuppressKeyPress = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                // Show the font dialog to allow the user to choose a font
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Change the font of the selected text
                    ChangeFontOfSelectedText(fontDialog.Font);
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void ChangeOverallFont(Font font)
        {
            richTextBox1.SelectionFont = font;
        }

        private void ChangeFontOfSelectedText(Font SelectedFont)
        {
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont = SelectedFont;
            }            
        }

        private void ChangeFontSizeOfSelectedText(int delta)
        {
            // Change the font size of the selected text by the specified delta
            if (richTextBox1.SelectionFont != null)
            {
                float currentSize = richTextBox1.SelectionFont.Size;
                float newSize = Math.Max(currentSize + delta, 1); // Ensure the font size is not less than 1

                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily, newSize);
            }
        }

        private void ToggleBold()
        {
            // Toggle the bold style for the current selection or the text to be inserted
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle currentStyle = richTextBox1.SelectionFont.Style;
                FontStyle newStyle = currentStyle ^ FontStyle.Bold; // Toggle Bold

                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont,
                    newStyle

                );
            }
        }


        private void ToggleItalic()
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle currentStyle = richTextBox1.SelectionFont.Style;
                FontStyle newStyle = currentStyle ^ FontStyle.Italic; 

                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont,
                    newStyle
                );
            }
        }


        private void ToggleUnderline()
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle currentStyle = richTextBox1.SelectionFont.Style;
                FontStyle newStyle = currentStyle ^ FontStyle.Underline;

                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont,
                    newStyle
                );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Font = new System.Drawing.Font("Times New Roman", 12);
        }
    }
}
