using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Tetris
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class User
    {
        public byte[] Login { get; private set; }
        public byte[] Password { get; private set; }
        public int BestScore;
        static public User[] Users { get; private set; } = new User[0];
        static private readonly int mSize = 64 + sizeof(int);
        static private readonly String mPath = "userdata";
        static private readonly HashAlgorithm sha256 = SHA256.Create();
        static User()
        {
            File.OpenWrite(mPath).Close();
            byte[] data = File.ReadAllBytes(mPath);
            byte[] bytes = new byte[mSize];
            for (int i = 0; i < data.Length / mSize; i++)
            {
                Buffer.BlockCopy(data, i * mSize, bytes, 0, mSize);
                Add(FromBytes(bytes));
            }
        }
        User()
        {
            Login = new byte[32];
            Password = new byte[32];
        }

        static public User Find(byte[] log)
        {
            return Users.Single(u => u.Login.SequenceEqual(log));
        }

        static public User Create(String log, String pas, int score = 0)
        {
            User user = new User();
            user.Login = sha256.ComputeHash(Encoding.UTF8.GetBytes(log));
            user.Password = sha256.ComputeHash(Encoding.UTF8.GetBytes(pas));
            user.BestScore = score;
            return user;
        }

        static public bool Add(String log, String pas)
        {
            return Add(Create(log, pas));
        }
        static public bool Add(User user)
        {
            if (!Exists(user.Login))
            {
                Users = Users.Append(user).ToArray();
                return true;
            }
            return false;
        }

        static public void Save()
        {
            byte[] data = new byte[mSize * Users.Length];
            for (int i = 0; i < data.Length / mSize; i++)
            {
                Buffer.BlockCopy(ToBytes(Users[i]), 0, data, i * mSize, mSize);
            }
            File.WriteAllBytes(mPath, data);
        }

        static public bool Exists(String log)
        {
            byte[] hashlog = sha256.ComputeHash(Encoding.UTF8.GetBytes(log));
            return Exists(hashlog);
        }
        static public bool Exists(byte[] hashlog)
        {
            return Users.Any(u => u.Login.SequenceEqual(hashlog));
        }

        static public bool Check(byte[] hashlog, byte[] hashpas)
        {
            return Users.Any(u =>
                 u.Login.SequenceEqual(hashlog) &&
                 u.Password.SequenceEqual(hashpas));
        } 
        static public bool Check(String log, String pas)
        {
            var hashlog = sha256.ComputeHash(Encoding.UTF8.GetBytes(log));
            var hashpas = sha256.ComputeHash(Encoding.UTF8.GetBytes(pas));
            return Check(hashlog, hashpas);
        }
        static public bool Check(User user)
        {
            return Check(user.Login, user.Password);
        }

        static private User FromBytes(byte[] bytes)
        {
            var data = new User();
            Buffer.BlockCopy(bytes, 0, data.Login, 0, 32);
            Buffer.BlockCopy(bytes, 32, data.Password, 0, 32);
            data.BestScore = BitConverter.ToInt32(bytes, 64);
            return data;
        }

        static private byte[] ToBytes(User user)
        {
            var ms = new MemoryStream();
            var bf = new BinaryWriter(ms);
            bf.Write(user.Login);
            bf.Write(user.Password);
            bf.Write(user.BestScore);
            return ms.ToArray();
        }
    }
}
