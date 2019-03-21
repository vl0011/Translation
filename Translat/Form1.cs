using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translation_API.Papago;


namespace Translat
{
    public partial class form_trans : Form
    {
        Papago papago = new Papago();

        Language source = Language.ko;
        Language target = Language.en;

        public form_trans()
        {
            papago.RegistTranslationEventHandler(translateHandler, null);
            InitializeComponent();
        }

        private void checkBox_top_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_top.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            string tmp = textBox_source.Text;
            textBox_source.Text = textBox_result.Text;
            textBox_result.Text = tmp;
        }

        private void button_translate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_source.Text))
                return;

            papago.Translate(source, target, textBox_source.Text.Replace("\r\n", " "));
        }

        private void translateHandler(object sender, PapagoTranslationEventArgs e)
        {
            textBox_result.Text = e.TranslationText;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_etok.Checked == true)
            {
                radioButton_ktoe.Checked = false;
                source = Language.en; target = Language.ko;
            }
            else if (radioButton_ktoe.Checked == true)
            {
                radioButton_etok.Checked = false;
                target = Language.en; source = Language.ko;
            }
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_result.Text))
                return;
            Clipboard.SetData(DataFormats.Text, (Object)textBox_result.Text);
        }
    }
}
