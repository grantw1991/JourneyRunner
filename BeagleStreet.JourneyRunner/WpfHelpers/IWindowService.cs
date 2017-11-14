﻿using System.Windows;

namespace BeagleStreet.JourneyRunner.WpfHelpers
{
    public interface IWindowService
    {
        void Show<T>(object context) where T : Window, new();

        void Show<T>() where T : Window, new();

        bool? ShowDialog<T>(object context) where T : Window, new();

        bool? ShowDialog<T>() where T : Window, new();
    }
}