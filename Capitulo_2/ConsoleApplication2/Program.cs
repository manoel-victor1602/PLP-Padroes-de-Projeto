using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Capitulo_2
{
    public class WeatherData : Subject
    {
        private ArrayList observers;
        private float temp;
        private float humidity;
        private float pressure;

        //construtor
        public WeatherData()
        {
            observers = new ArrayList();
        }
        //fim construtor

        //metodos get
        public float getTemperature()
        {

            return this.temp;
        }
        public float getHumidity()
        {
            return this.humidity;
        }
        public float getPressure()
        {
            return this.pressure;
        }
        //fim metodos get

        //metodos da interface
        public void registerObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            int i = observers.IndexOf(o);

            if (i >= 0)
                observers.Remove(i);
        }

        public void notifyObserver()
        {
            /*IObserver[] v = new IObserver[observers.Count];
            observers.ToArray(v);*/

            for (int i = 0; i < observers.Count; i++)
            {
                IObserver observer = (IObserver) observers[i];
                observer.update(temp, humidity, pressure);
            }
        }
        //fim dos metodos da interface

        //metodos de mediçao
        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temp = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }

        public void measurementsChanged()
        {
            notifyObserver();
        }
        //fim metodos de mediçao

    }
    public class CurrentConditionsDisplay : IObserver, DisplayElement
    {
        private float temp;
        private float humidity;
        private float pressure;
        private Subject weatherData;

        //metodo construtor
        public CurrentConditionsDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        //fim metodo construtor

        //metodos herdados
        public void display()
        {
            Console.WriteLine("Temperatura: " + temp +
                             "\nHumidade: " + humidity +
                             "\nPressao: " + pressure + "\n\n");

        }

        public void update(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }
        //fim metodos herdados

    }
    public interface Subject
    {
        void registerObserver(IObserver o);
        void removeObserver(IObserver o);
        void notifyObserver();
    }
    public interface IObserver
    {
        void update(float temp, float humidity, float pressure);
    }
    public interface DisplayElement
    {
        void display();
    }
    public class WeatherStation
    {
        public static void Main(String[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);

            //Teste 1-------------------------------------------------------------
            weatherData.setMeasurements(80,65,30.4f);

            //Teste 2-------------------------------------------------------------
            weatherData.setMeasurements(82, 70, 29.2f);

            //Teste 3-------------------------------------------------------------
            weatherData.setMeasurements(78, 90, 29.2f);

            Console.ReadLine();
        }
    }
}