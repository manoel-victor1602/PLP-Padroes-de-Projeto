using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo_7_Facade
{
    class Amplifier
    {
        public void on()
        {

        }
        public void off()
        {

        }
        public void setDvd(DvdPlayer dvd)
        {

        }
        public void setSurroundSound()
        {

        }
        public void setVolume(int num)
        {

        }
    }
    class Tuner
    {

    }
    class DvdPlayer
    {
        public void on()
        {

        }
        public void play(String movie)
        {

        }
        public void stop()
        {

        }
        public void eject()
        {

        }
        public void off()
        {

        }
    }
    class CdPlayer
    {

    }
    class Projector
    {
        public void wideScreenMode()
        {

        }
        public void on()
        {

        }
        public void off()
        {

        }
    }
    class TheaterLights
    {
        public void dim(int num)
        {

        }
        public void on()
        {

        }
    }
    class Screen
    {
        public void down()
        {

        }
        public void up()
        {

        }
    }
    class PopcornPopper
    {
        public void on()
        {

        }
        public void off()
        {

        }
        public void pop()
        {

        }
    }
    class HomeTheaterFacade 
    {
        Amplifier amp;
        Tuner tuner;
        DvdPlayer dvd;
        CdPlayer cd;
        Projector projector;
        TheaterLights lights;
        Screen screen;
        PopcornPopper popper;

        public HomeTheaterFacade(Amplifier amp, Tuner tuner, DvdPlayer dvd, CdPlayer cd,
                                 Projector projector, Screen screen, TheaterLights lights, PopcornPopper popper)
        {
            this.amp = amp;
            this.tuner = tuner;
            this.dvd = dvd;
            this.cd = cd;
            this.projector = projector;
            this.screen = screen;
            this.lights = lights;
            this.popper = popper;
        }
        public void watchMovie(String movie)
        {
            Console.WriteLine("Get ready to watch a movie...");

            popper.on();
            popper.pop();

            lights.dim(10);

            screen.down();

            projector.on();
            projector.wideScreenMode();

            amp.on();
            amp.setDvd(dvd);
            amp.setSurroundSound();
            amp.setVolume(5);

            dvd.on();
            dvd.play(movie);
        }
        public void endmovie()
        {
            Console.WriteLine("Shutting movie theater down...");

            popper.off();

            lights.on();

            screen.up();

            projector.off();

            amp.off();

            dvd.stop();
            dvd.eject();
            dvd.off();
        }
    }
    class HomeTheaterTestDrive
    {
        public static void Main(String[] args)
        {
            Amplifier amp = new Amplifier();
            Tuner tuner = new Tuner();
            DvdPlayer dvd = new DvdPlayer();
            CdPlayer cd = new CdPlayer();
            Projector projector = new Projector();
            TheaterLights lights = new TheaterLights();
            Screen screen = new Screen();
            PopcornPopper popper = new PopcornPopper();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(amp, tuner, dvd, cd, projector, screen, lights, popper);

            homeTheater.watchMovie("Raiders of the Lost Ark");
            homeTheater.endmovie();
        }
    }

}
