using System;
using UnityEngine;
using TMPro;

public class TerminalController : MonoBehaviour
{
    [SerializeField] private TMP_Text m_output;
    [SerializeField] private TMP_Text m_input;

    public event Action<string> OnCommandEntered;

    private string m_currentLine = "";
    private bool m_entered;

    void Update()
    {
        if (!m_entered) return;

        foreach (char c in Input.inputString)
        {
            if (c == '\b') 
            {
                if (m_currentLine.Length > 0)
                    m_currentLine = m_currentLine.Substring(0, m_currentLine.Length - 1);
            }
            else if (c == '\n' || c == '\r') 
            {
                SubmitLine();
            }
            else
            {
                m_currentLine += c;
            }
        }

        m_input.text = "> " + m_currentLine + "|";
    }

    private void SubmitLine()
    {
        m_output.text = "== ESA Terminal ==\n";

        if (string.IsNullOrWhiteSpace(m_currentLine))
        {
            m_currentLine = "";
            return;
        }

        m_output.text += "> " + m_currentLine + "\n";
        OnCommandEntered?.Invoke(m_currentLine);
        m_currentLine = "";
    }

    private void Start()
    {
        EnableText(false);
    }

    private void EnableText(bool en)
    {
        m_output.gameObject.SetActive(en);
        m_input.gameObject.SetActive(en);
    }

    public void OnEnter()
    {
        m_entered = true;
        EnableText(true);
        m_output.text = "== ESA Terminal ==\nType a command...\n";
        m_currentLine = "";
    }

    public void Print(string line) => m_output.text += line + "\n";
    public void Clear() => m_output.text = "== ESA Terminal ==\n";

    public void OnLeave()
    {
        m_entered = false;
        EnableText(false);
        m_currentLine = "";
    }
}