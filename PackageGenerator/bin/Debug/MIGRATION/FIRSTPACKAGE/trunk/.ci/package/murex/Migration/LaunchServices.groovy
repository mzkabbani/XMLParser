package murex.MXpress;



public class LaunchServices extends Orchestrator{
public LaunchMXpressServices(def ApplicationDirectoryPath){
	FrontendUtilities utils = new FrontendUtilities();
	utils.SetUtilsAppdirPath(ApplicationDirectoryPath)
	
	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==================================================================================================================")
	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "============================= MXpress-Installer - Stage 2 - Launches services ====================================")
	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==================================================================================================================")

	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Launch MX.3 services =====")

	//utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/MXpress-Installer-launchall.sh", new File(ApplicationDirectoryPath))
	//def commandText = ApplicationDirectoryPath +"/MXpress-Installer-launchall.sh"
	//def proc = commandText.execute(null, new File(ApplicationDirectoryPath))
	//proc.waitFor();
	 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Launch FS =====")
	
	 utils.ExecuteCommandInShell("launchmxj.app -fs", new File(ApplicationDirectoryPath))
		
	 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Launch FS =====")
		
	
	def ant = new AntBuilder()   
					ant.exec(failonerror: "false",executable: ApplicationDirectoryPath+"/MXpress-Installer-launchall.sh")
			
	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Launch MX.3 services =====")
	
	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==================================================================================================================")
	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "============================= MXpress-Installer - Stage 2 - Launches services ====================================")
	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==================================================================================================================")

	
	
}


	
}
