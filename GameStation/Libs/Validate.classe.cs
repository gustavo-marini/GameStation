using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GameStation.Libs
{
    class Validate
    {
        private List<string> errors;

        public Validate() {

        }


        public bool onlyLetters(TextBox field, string field_name, string message="") {
            string field_text = field.Text.ToString();
            if (field_text.Length > 0) {
                Regex textPattern = new Regex("^[0-9A-Za-z ]+$");

                if (textPattern.IsMatch(field_text)) {
                    return true;
                } else  {
                    if(message.Length > 0) {
                        errors.Add(message);
                    } else {
                        errors.Add("O campo \"" + field_name + "\" pode conter somente letras e espaços em branco.");
                    }
                    return false;

                }
            }
            errors.Add("O campo \"" + field_name + "\" é obrigatório.");
            return false;
        }


        public bool email(TextBox field, string field_name, string message = "")
        {
            string field_text = field.Text.ToString();
            if (field_text.Length > 0)
            {
                try
                {
                    MailAddress ma = new MailAddress(field_text);
                    return ma.Address == field_text;
                }
                catch(Exception)
                {
                    if (message.Length > 0)
                    {
                        errors.Add(message);
                    }
                    else
                    {
                        errors.Add("Por favor, insira um email válido.");
                    }
                    return false;
                }
            }
            errors.Add("O campo \"" + field_name + "\" é obrigatório.");
            return false;
        }


        public bool date(MaskedTextBox field, string field_name, string message = "") {
            string field_text = field.Text.ToString();
            int field_size = field_text.Length;
            
            if(field_size == 10) {
                try {
                    dynamic birth = Basics.getBirthdate(field_text);
                    DateTime date = new DateTime(birth.year, birth.month, birth.day);
                    int compare = date.CompareTo(DateTime.Now);
                    
                    if(compare < 0) {
                        return true;
                    }

                    if (message.Length > 0) {
                        errors.Add(message);
                    } else {

                    }
                    errors.Add("O campo \"" + field_name + "\" precisa ter uma data menor que o dia atual.");
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            errors.Add("Por favor, insira a data corretamente.");
            return false;
        }


        public bool validateCpf(MaskedTextBox field, string field_name, string message = "") {
            string field_text = field.Text.ToString();
            int field_size = field_text.Length;

            if (field_size == 14) {
                try {
                    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                    string tempCpf;
                    string digito;
                    int soma;
                    int resto;

                    field_text = field_text.Trim();
                    field_text = field_text.Replace(".", "").Replace("-", "");

                    tempCpf = field_text.Substring(0, 9);
                    soma = 0;

                    for (int i = 0; i < 9; i++) {
                        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                    }
                    resto = soma % 11;
                    if (resto < 2) resto = 0;
                    else resto = 11 - resto;

                    digito = resto.ToString();
                    tempCpf = tempCpf + digito;
                    soma = 0;

                    for (int i = 0; i < 10; i++) {
                        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                    }

                    resto = soma % 11;
                    if (resto < 2) resto = 0;
                    else resto = 11 - resto;

                    digito = digito + resto.ToString();

                    if (field_text.EndsWith(digito)) {
                        return true;
                    }

                    if (message.Length > 0) {
                        errors.Add(message);
                    } else {
                        errors.Add("O campo \"" + field_name + "\" é inválido.");
                    }
                    return false;
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            errors.Add("Por favor, digite um CPF válido");
            return false;
        }


        public bool required(TextBox field, string field_name, string message = "")
        {
            try {
                if (field.Text.ToString().Length > 0) {
                    return true;
                } else {
                    if (message.Length > 0) {
                        errors.Add(message);
                    } else {
                        errors.Add("O campo \"" + field_name + "\" é obrigatório.");
                    }
                    return false;
                }
            } catch {
                return false;
            }
        }

        public bool required(MaskedTextBox field, string field_name, string message = "") {
            try {
                if(field.MaskFull) {
                    return true;
                } else {
                    if(message.Length > 0) {
                        errors.Add(message);
                    } else {
                        errors.Add("O campo \"" + field_name + "\" é obrigatório.");
                    }
                    return false;
                }
            } catch {
                return false;
            }
        }

        public bool Required(TextBox field, string field_name, string message = "")
        {
            try {
                if (field.TextLength > 0) {
                    return true;
                } else {
                    if (message.Length > 0) {
                        errors.Add(message);
                    } else {
                        errors.Add("O campo \"" + field_name + "\" é obrigatório.");
                    }
                    return false;
                }
            } catch {
                return false;
            }
        }

    }
}
