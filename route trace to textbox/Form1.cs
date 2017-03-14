using System;
using System.Windows.Forms;
using System.Diagnostics;
namespace route_trace_to_textbox
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      TextBoxTraceListener textBoxTraceListener = new TextBoxTraceListener();
      Trace.Listeners.Add(textBoxTraceListener);
      textBoxTraceListener.FireUpdateTextBoxEvent += new TextBoxTraceListener.UpdateTextBoxDelegate(OnUpdateTextBoxEvent);
    }
    void OnUpdateTextBoxEvent(string strValue)
    {
      Invoke((MethodInvoker)delegate
      {
        textBox1.AppendText(strValue);
        int nLineCount = textBox1.Lines.GetLength(0);
        if (nLineCount > 15)
        {
          textBox1.Text = textBox1.Text.Remove(0, textBox1.Lines[0].Length + 2);
        }
      });
    }
    int nCount = 0;
    private void button1_Click(object sender, EventArgs e)
    {
      Trace.WriteLine("Trace Message" + nCount++);
    }
  }
}
