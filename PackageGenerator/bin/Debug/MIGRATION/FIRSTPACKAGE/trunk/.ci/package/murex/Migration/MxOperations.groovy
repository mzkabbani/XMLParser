package murex.MXpress;

public class MxOperations  extends Orchestrator{


	public RunOperations(def ApplicationDirectoryPath, def BackupDirectoryPath){
		FrontendUtilities utils = new FrontendUtilities();
		utils.SetUtilsAppdirPath(ApplicationDirectoryPath)
		
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================MXpress-Installer - Stage 1 - Applicative directory customization starts =======================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")


		//Relocate fs/MXpress-Installer/MXpress-Installer-launchall.sh under apps dir. Required to enable file dynamic content
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Moving fs/MXpress-Installer/MXpress-Installer-launchall.sh to apps dir root. =====")
		utils.CopyFile(ApplicationDirectoryPath + "/fs/MXpress-Installer/MXpress-Installer-launchall.sh", ApplicationDirectoryPath + "/MXpress-Installer-launchall.sh")
		utils.ChmodFile(new File(ApplicationDirectoryPath + "/MXpress-Installer-launchall.sh"), 777)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Moving fs/MXpress-Installer/MXpress-Installer-launchall.sh to apps dir root. =====")
	
		
		//fs/MXpress-Installer/MXpress-launchall.sh under apps dir. Required to enable file dynamic content
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Moving fs/MXpress-Installer/MXpress-launchall.sh to apps dir root. =====")
		utils.CopyFile(ApplicationDirectoryPath + "/fs/MXpress-Installer/MXpress-launchall.sh", ApplicationDirectoryPath+"/MXpress-launchall.sh");
		utils.ChmodFile(new File(ApplicationDirectoryPath + "/MXpress-launchall.sh"), 777);
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Moving fs/MXpress-Installer/MXpress-launchall.sh to apps dir root. =====");


		//Update fs/public/mxres/common/launcherall.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Updating fs/public/mxres/common/launcherall.mxres =====")
		utils.BackupFile(ApplicationDirectoryPath +"/fs/public/mxres/common/launcherall.mxres",ApplicationDirectoryPath,BackupDirectoryPath)
		//still have additional work here with xsl and launchers
		DeployOperationsHelpers helpers = new DeployOperationsHelpers();
		helpers.UpdateLaunchers(ApplicationDirectoryPath +"/logs/MXpress-Installer/output/trash", ApplicationDirectoryPath);
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Finished fs/public/mxres/common/launcherall.mxres =====")

		//Apply to launchermxsession.mxres same customizations done for launcherall.mxres, MXSESSION code.
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/common/launchermxsession.mxres =====")
		def mxsessionAdd= utils.ReadFile(new File(ApplicationDirectoryPath +"/CleanDeploy/launcherall/MXSESSION.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxsession.mxres"), "</DefaultCommands>", mxsessionAdd)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/common/launchermxsession.mxres =====")

		//Update fs/public/mxres/common/launchermxprocessingrof.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/common/launchermxprocessingrof.mxres =====")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxprocessingrof.mxres"), "</DefaultCommands>", "<MxAnchor MxAnchor=&quot;public.mxres.common.launchermxpresssettings.mxres#MXPROCESSINGSCRIPT_ROF-LOG&quot; MxAnchorType=\'Include\'/>\r\n</DefaultCommands>");
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/common/launchermxprocessingrof.mxres =====")

		//Update fs\public\mxres\common\launchermxdatapublisher.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/common/launchermxdatapublisher.mxres =====")
		utils.BackupFile(ApplicationDirectoryPath +"/fs/public/mxres/common/launchermxdatapublisher.mxres",ApplicationDirectoryPath,BackupDirectoryPath);
		utils.RunXSLT(new File(ApplicationDirectoryPath +"/CleanDeploy/mxdatapublisher/dp.xsl"), new File(ApplicationDirectoryPath +"/fs/public/mxres/common/launchermxdatapublisher.mxres")) // need to update to correct path
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/common/launchermxdatapublisher.mxres =====")

		//DEF0197980 no longer required -> shift from epad to warehouse blotter
		//utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxdistribution/properties.mxres =====")
		//utils.RegexReplaceInFile(new File(ApplicationDirectoryPath +"/fs/public/mxres/mxdistribution/properties.mxres"), "Idle", "Active")
		//utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxdistribution/properties.mxres =====")


		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxdistribution/spaces/epad_space.mxres =====")
		def replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/spaces/added_to_epad_space.mxres"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxdistribution/spaces/epad_space.mxres"), "</MxAnchor>", replacement)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxdistribution/spaces/epad_space.mxres =====")

		
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxdistribution/spaces/epad_space_gui.mxres =====")
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/spaces/added_to_epad_space_gui.mxres"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxdistribution/spaces/epad_space_gui.mxres"), "</MxAnchor>", replacement)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxdistribution/spaces/epad_space_gui.mxres =====")
		

		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/guiclient/profile/client.mxres =====")
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/ntclient/client_add.mxres"));
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/guiclient/profile/client.mxres"), "</Screen>", replacement)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/guiclient/profile/client.mxres =====")


		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxwarehouse/startup.mxres =====")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath +"/fs/public/mxres/mxwarehouse/startup.mxres"), "<Valid>.*</Valid>", "<Valid>Y</Valid>")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxwarehouse/startup.mxres =====")

		//Update fs/public/mxres/mxwarehouse/fxmmsettings.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxwarehouse/fxmmsettings.mxres =====")
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/fxmmsettings/FX.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxwarehouse/fxmmsettings.mxres"), "<MxAnchor Code=\"PS_FX_VIEW\">", replacement)
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/fxmmsettings/GEN.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxwarehouse/fxmmsettings.mxres"), "<MxAnchor Code=\"PS_GEN_VIEW\">", replacement)
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/fxmmsettings/MM.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxwarehouse/fxmmsettings.mxres"), "<MxAnchor Code=\"PS_MM_VIEW\">", replacement)
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/fxmmsettings/SEC_FIN.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxwarehouse/fxmmsettings.mxres"), "</MxAnchors>", replacement)		
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/fxmmsettings/COM.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxwarehouse/fxmmsettings.mxres"), "</MxAnchors>", replacement)
	
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxwarehouse/fxmmsettings.mxres =====")

		//update mxmlexguimonitor.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxmlexchange/client/gui/mxmlexguimonitor.mxres =====")
		utils.BackupFile(ApplicationDirectoryPath+"/fs/public/mxres/mxmlexchange/client/gui/mxmlexguimonitor.mxres",ApplicationDirectoryPath,BackupDirectoryPath)
		def mxmlguiAdd = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/mxmlguimonitor/mxmlguimonitor_add.xml"));
		utils.RunXSLT(new File(ApplicationDirectoryPath+"/CleanDeploy/mxmlguimonitor/mxmlguimonitor.xsl"), new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlexchange/client/gui/mxmlexguimonitor.mxres"), "guimonitADD", mxmlguiAdd)
		utils.CopyFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlexchange/client/gui/mxmlexguimonitor.mxres"), new File(BackupDirectoryPath+"/fs/public/mxres/mxmlexchange/client/gui/mxmlexguimonitor_2.mxres"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlexchange/client/gui/mxmlexguimonitor.mxres"), "<MxAnchor Code=\"SortSheets\">N</MxAnchor>", "<MxAnchor Code=\"SortSheets\">Y</MxAnchor>")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxmlexchange/client/gui/mxmlexguimonitor.mxres =====")

		//Update mxmlexchange/ddDependenciesRequest.xml
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating mxmlexchange/ddDependenciesRequest.xml =====")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/mxmlexchange/ddDependenciesRequest.xml"), "<Renderer type=\'XML\' dumpPath=\'D:\\Dump\\script_dump\'/>", "<Renderer type=\'TEXT\' dumpPath=\'\\./ddDependenciesOutput\'/>")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating mxmlexchange/ddDependenciesRequest.xml =====")

		//update fs/public/mxres/common/dbconfig/mxservercredential.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/common/dbconfig/mxservercredential.mxres =====")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/mxservercredential.mxres"), "(CTLIBDefaultCredential.*[\r\n]*?.*USER:)MUREXBO(.*)", "\$1MUREXFO\$2")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/mxservercredential.mxres"), "(CTLIBDefaultCredential.*[\r\n]*?.*[\r\n]*?.*/PASSWORD:0010002000410047001600)b(70067</DefaultCommand>)", "\$1f\$2")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/mxservercredential.mxres"), "(CTLIBDefaultCredential.*[\r\n]*?.*[\r\n]*?.*[\r\n]*?.*/GROUP:)BO(.*)", "\$1FO\$2")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/mxservercredential.mxres"), "(CTLIBMOCredential.*[\r\n]*?.*USER:)(.*)", "\$1MUREXBO\$2")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/mxservercredential.mxres"), "(CTLIBMOCredential.*[\r\n]*?.*[\r\n]*?.*<DefaultCommand>)/PASSWORD:</DefaultCommand>", "\$1/PASSWORD:0010002000410047001600b70067</DefaultCommand>")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/mxservercredential.mxres"), "(CTLIBMOCredential.*[\r\n]*?.*[\r\n]*?.*[\r\n]*?.*GROUP:)(.*)", "\$1MO_SRV\$2")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/common/dbconfig/mxservercredential.mxres =====")

		//increase MXMLSECONDARY service jvm in  mxg2000_settings.sh
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating mxg2000_settings.sh MXMLSECONDARY_JVM_ARGS =====")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/mxg2000_settings.sh"), "(#MXMLSECONDARY_JVM_ARGS=\")(-Xms\\d+M)( -Xmx\\d+M)(.*?)\"", "MXMLSECONDARY_JVM_ARGS=\"-Xms128M -Xmx1024M\$4 -XX:+HeapDumpOnOutOfMemoryError\"")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating mxg2000_settings.sh MXMLSECONDARY_JVM_ARGS =====")

		//Add MXML_JVM_AGRS java core dump option in  mxg2000_settings.sh
		//utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating mxg2000_settings.sh MXML_JVM_ARGS =====")//whats $MXML_JVM_ARGS ?????
	//	def JVM = "\$MXML_JVM_ARGS";
	//	utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/mxg2000_settings.sh"), "(#MXML_JVM_ARGS=.*)", "\$1\r\nMXML_JVM_ARGS=\'${JVM} -Djava.awt.headless=true\'")
	//	utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating mxg2000_settings.sh MXML_JVM_ARGS =====")

		//update fileserver.mxres to add file extensions
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/fs/fileserver.mxres =====")
		replacement = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/fileserver/add_extensions.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/fs/fileserver.mxres"), "<MxAnchor Code=\"SUPPORTED_FILE\">", replacement)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/fs/fileserver.mxres =====")

		//Update fs\public\mxres\loggers\common_logger.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/loggers/common_logger.mxres =====")
		//following MXpress DEF0213302, MxML Data Dictionary log are kept to their default value: OFF
		//utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/loggers/common_logger.mxres"), "(.*)(CommonLoggersConfig)(.*?)<level value=\'OFF\'/>(.*)", "\$1\$2\$3<level value=\'DEBUG\'/>\$4")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/loggers/common_logger.mxres"), "(.*)(CommonRootLevelConfig)(.*?)<level value=\'OFF\'/>(.*)", "\$1\$2\$3<level value=\'ERROR\'/>\$4")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/loggers/common_logger.mxres =====")

		//Add parameters to ClientMacro section in launchmxj.app as of DEF0156645
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating launchmxj.app adding ClientMacro section =====")// whats $EXTRA_ARGS ????
		def EXTRA = "\$EXTRA_ARGS"
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/launchmxj.app"), "(.*?ClientMacro.*?)${EXTRA}(.*exit \$\\?)", "\$1\\/MXJ_POP_CONNECTION_TIME_OUT:240000 /MXJ_PING_POP_GUI_DOCUMENT:10 ${EXTRA}\$2")
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/launchmxj.app"), 777)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating launchmxj.app adding ClientMacro section =====")

		//fix permission for launchall.sh
		//eravex: 2011-02-25 - likely to be deprecated
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/MXpress-launchall.sh"), 777)
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/MXpress-Installer-launchall.sh"), 777)


		//Update fs/public/mxres/mxinterfaces/markit/markit-properties.mxres
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxinterfaces/markit/markit-properties.mxres =====")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxinterfaces/markit/markit-properties.mxres"), "(markit.mapping.sectors.rootLabel=Sectors)", "markit.mapping.sectors.rootLabel=Sectors_ICB")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxinterfaces/markit/markit-properties.mxres =====")



		//Update fs/public/mxres/common/launchermxmlexchangesecondary.mxres
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxmlexchangesecondary.mxres"), "<!--(\n\\s+<AvailableService>\n\\s+<Code>MXMLEXCHANGE</Code>\n\\s+<Import>\n\\s+<RefNickName>MXMLEXCHANGE.ARCHIVE.SPACES</RefNickName>)", "\$1")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxmlexchangesecondary.mxres"), "(<NickName>CL.MXMLEXCHANGE.ARCHIVE.SPACES</NickName>.*?</AvailableService>\n\\s+)-->", "\$1")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxmlexchangesecondary.mxres"), "public(.mxres.mxmlexchange.spaces.mxarchivespace.mxres)", "murex\$1")
			

		//Update fs/public/mxres/common/launchermxtraderepository.mxres
		def inEng = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/launchermxrepository/engine.xml"))
		def inEngPlc = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/launchermxrepository/engine_plc.xml"))
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxrepository.mxres"), "(MXTRADEREPOSITORY.ENGINE</NickName>\\n\\s+<Customize>\\s\\s+<DefaultCommands>)", "\$1\r\n$inEng")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxrepository.mxres"), "(MXTRADEREPOSITORY.ENGINE.PLC</NickName>\n\\s+<Customize>\\s\\s+<DefaultCommands>)", "\$1\r\n$inEngPlc")

		//Update fs/public/mxres/common/launchermxsmcrisk.mxres
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxsmcrisk.mxres"), "<!--Import>", "<Import>")
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxsmcrisk.mxres"), "</Import-->", "</Import>")

		//Implementation of MXSOAPREGISTRY service
		def file = (new File(ApplicationDirectoryPath+"/freeport_res.log")).delete()
		def useRandom = utils.GenerateRandomNumber(10000,32768)
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/get_free_port.sh"), 777)
			
		utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/get_free_port.sh $useRandom", new File(ApplicationDirectoryPath))
		// may want to check ${application.directory.path}/freeport_res.log for port number

		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launcherall.mxres"), "(<DefaultCommand>/MXJ_SOAP_PORT:12345</DefaultCommand>)", "<DefaultCommand>/MXJ_SOAP_PORT:$useRandom</DefaultCommand>")
		
		file = (new File(ApplicationDirectoryPath+"/freeport_res.log")).delete()
		useRandom = utils.GenerateRandomNumber(10000,32768)
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/get_free_port.sh"), 777)
			
		utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/get_free_port.sh $useRandom", new File(ApplicationDirectoryPath))
		
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launcherall.mxres"), "9090", "$useRandom")		
		file = (new File(ApplicationDirectoryPath+"/freeport_res.log")).delete()
		useRandom = utils.GenerateRandomNumber(10000,32768)
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/get_free_port.sh"), 777)
			
		utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/get_free_port.sh $useRandom", new File(ApplicationDirectoryPath))
		
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launcherall.mxres"), "9092", "$useRandom")		
		file = (new File(ApplicationDirectoryPath+"/freeport_res.log")).delete()
		useRandom = utils.GenerateRandomNumber(10000,32768)
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/get_free_port.sh"), 777)
			
		utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/get_free_port.sh $useRandom", new File(ApplicationDirectoryPath))
		
		utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launcherall.mxres"), "9094", "$useRandom")
		

		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "================= MXpress-Installer - Stage 1 - Applicative directory customizations completed ===================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==================================================================================================================")

		
		}	
}
