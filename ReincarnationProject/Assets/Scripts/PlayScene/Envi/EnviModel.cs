using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationName
{
    None,
    City,
    Forest
}
public enum WeatherName
{
    None,
    Sunny,
    Rainy,
    Cloudy
}
public enum TimeName
{
    None,
    Day,
    Night
}
public class EnviModel : MonoBehaviour {

    public LocationName m_curLocation;
    public WeatherName m_curWeather;
    public TimeName m_curTime;

    public void Init()
    {
        m_curLocation = LocationName.City;
        m_curWeather = WeatherName.Sunny;
        m_curTime = TimeName.Day;
    }
}
