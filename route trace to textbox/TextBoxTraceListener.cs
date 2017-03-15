//
using System;
namespace route_trace_to_textbox
{
  public class TextBoxTraceListener : System.Diagnostics.TraceListener
  {
    public delegate void UpdateTextBoxDelegate(string strValue);
    public event UpdateTextBoxDelegate FireUpdateTextBoxEvent;
    public override void Write(String message)
    // You define these and put the message into your textbox.
    {
      FireUpdateTextBoxEvent(message);
    }
    public override void WriteLine(String message)
    // You define these and put the message into your textbox.
    {
      FireUpdateTextBoxEvent(message + "\r\n");
    }
  }
}

