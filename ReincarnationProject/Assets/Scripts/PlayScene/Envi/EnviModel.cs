using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationName
{
    None,
    City,
    Forest,
    DeepForest
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

    public LocationName m_prevLocation;
    public WeatherName m_prevWeather;
    public TimeName m_prevTime;

    public void Init()
    {
        m_prevLocation = m_curLocation = LocationName.City;
        m_prevWeather = m_curWeather = WeatherName.Sunny;
        m_prevTime = m_curTime = TimeName.Day;
    }
    public void ChangeLocation(LocationName _location)
    {
        m_prevLocation = m_curLocation;
        m_curLocation = _location;
    }
    public void ChangeWeather(WeatherName _weather)
    {
        m_prevWeather = m_curWeather;
        m_curWeather = _weather;
    }
    public void ChangeTime(TimeName _time)
    {
        m_prevTime = m_curTime;
        m_curTime = _time;
    }
}
