const randint = (left, right) => Math.floor((Math.random()*(right - left)) + left)
const template = () => ({
      "AverageDayTemperature":randint(-30, 30),
      "AverageNightTemperature":randint(-40, 21),
      "AverageAtmosphericPressure":randint(400, 1341),
      "PrecipitationMmDay":randint(0, 300),
      "WeatherType":randint(0, 8)
})
console.log(JSON.stringify(Array.from(Array(30)).map(() => template())))