﻿using System;
using System.Linq;
using System.Net.Mail;

namespace Following
{
    public class SendMail
    {
        public static bool CheckMail(string address)
        {
            string[] mails = address.Split('@');
            if (!address.Contains(' ')
                && !address.Contains('\'')
                && !address.Contains('\"')
                && !address.Contains('#')
                && !address.Contains('$')
                && !address.Contains('%')
                && !address.Contains('^')
                && !address.Contains('&')
                && !address.Contains('(')
                && !address.Contains(')')
                && !address.Contains('*')
                && !address.Contains('=')
                && !address.Contains('+')
                && !address.Contains('`')
                && !address.Contains('~')
                && !address.Contains('{')
                && !address.Contains('}')
                && !address.Contains('\\')
                && !address.Contains('|')
                && !address.Contains(';')
                && !address.Contains(',')
                && !address.Contains(':')
                && !address.Contains('<')
                && !address.Contains('>')
                && !address.Contains('/')
                && !address.Contains('?')
                && mails.Length >= 2
                && (mails[mails.Length - 1] == "gmail.com"
                || mails[mails.Length - 1] == "mail.ru"
                || mails[mails.Length - 1] == "bk.ru"
                || mails[mails.Length - 1] == "list.ru"
                || mails[mails.Length - 1] == "inbox.ru"
                || mails[mails.Length - 1] == "yandex.ru"))
                return true;
            else return false;
        }
        public static void TextMessage(string address, string name, out string pin, string password)
        {
            string[] mails = address.Split('@');
            pin = Password.PinCodeGen();

            string sender;
            MailMessage mail;


            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                switch (mails[mails.Length - 1])
                {
                    case "mail.ru":
                    case "bk.ru":
                    case "list.ru":
                    case "inbox.ru":
                        client.Host = "smtp.mail.ru";
                        client.Credentials = new System.Net.NetworkCredential("avo1000@mail.ru", "qazwsx96");
                        sender = "sahakyan-m15@mail.ru";
                        break;
                    case "gmail.com":
                        client.Host = "smtp.gmail.com";
                        client.Credentials = new System.Net.NetworkCredential("avoforvs@gmail.com", "sendmessage");
                        sender = "avoforvs@gmail.com";
                        break;
                    case "yandex.ru":
                        client.Host = "smtp.yandex.ru";
                        client.Credentials = new System.Net.NetworkCredential("your yandex address", "password");
                        sender = "your yandex address";
                        break;
                    default: sender = ""; break;
                }

                mail = new MailMessage(sender, address);
                mail.Subject = "Following";

                mail.Body = $"Hi Dear {name}! \nYou are followed in most read news of BlogNews\nThis is your PIN code for verify your account: {pin}\nYour password :{password}";

                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{address} email was wrong ");
            }

        }
    }
}
