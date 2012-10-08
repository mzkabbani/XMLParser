package murex.MXpress

public class Maintenance extends Orchestrator{

	public RunOperations(def ApplicationDirectoryPath, boolean fullMainenance){
		FrontendUtilities utils = new FrontendUtilities()
		utils.SetUtilsAppdirPath(ApplicationDirectoryPath)

		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "========================== MXpress-Installer - Stage 2.1 - Maintenance    =======================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")



		if	(fullMainenance){
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Full Maintenance =====")
			utils.ExecuteCommandInShell("launchmxj.app -c -scriptant /MXJ_ANT_BUILD_FILE:public.mxres.script.assembly.MXpress-Install-Navigation-Maintenance.mxres /MXJ_ANT_TARGET:install > $ApplicationDirectoryPath/MXpress-Installer-maintenance.log", new File(ApplicationDirectoryPath))
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Full Maintenance =====")
		}else{
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Navigation Maintenance =====")
			utils.ExecuteCommandInShell("launchmxj.app -c -scriptant /MXJ_ANT_BUILD_FILE:public.mxres.script.assembly.MXpress-Install-Navigation-Maintenance.mxres /MXJ_ANT_TARGET:install > $ApplicationDirectoryPath/MXpress-Installer-maintenance.log", new File(ApplicationDirectoryPath))
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Navigation Maintenance =====")
		}


		utils.CopyFile("$ApplicationDirectoryPath/logs/assembly-audit.log", "$ApplicationDirectoryPath/logs/mxodr/mxodrassembly/service_MXPRESS_Maintenance.log")



		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "========================== MXpress-Installer - Stage 2.1 - Maintenance completed ====================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
	}
}
