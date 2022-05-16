type GUID = string & { isGuid: true };
function guid(guid: string): GUID {
  return guid as GUID;
}

export interface Weather {
  id: GUID;
  location: string;
  temperature: string;
  wind: string;
  cloudiness: string;
  icon: string;
  liveCity: string;
  liveWeather: string;
}
