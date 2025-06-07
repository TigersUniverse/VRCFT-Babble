using Newtonsoft.Json;
using System.Reflection;

namespace VRCFaceTracking.Babble;

public static class BabbleConfig
{
	private const string BabbleConfigFile = "BabbleConfig.json";

	public static Config GetBabbleConfig()
	{
      string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
		string path = Path.Combine(directoryName, BabbleConfigFile);
		if(!File.Exists(path)) File.WriteAllText(path, JsonConvert.SerializeObject(new Config
		{
			Host = BabbleOSC.DEFAULT_HOST,
			Port = BabbleOSC.DEFAULT_PORT
		}));
		string value = File.ReadAllText(path);
		return JsonConvert.DeserializeObject<Config>(value)!;
	}
}
