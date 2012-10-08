package murex.Migration;

public class Operations {
	
	public def StartMigration(def AppDir, def logDir, def backupDir, Map<String, Object> properties){		
		println "AppDir======>" + AppDir;
		println "logDir======>" + logDir;
		println "backupDir===>" + backupDir;		
		properties.values().each { println it.toString() }
		println "====>>"+ properties.get("Customiztions_Logs_Dir");
		
		FrontendUtilities frontEndUtilities = new FrontendUtilities();
		frontEndUtilities.SetUtilsAppdirPath(AppDir);
		frontEndUtilities.SetUtilsLogDir(logDir);
		frontEndUtilities.SetUtilsBackupDir(backupDir);
		
		//Start-Operations
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild( "D:/Migration-Input-Files/launchermxprocessingrof.mxres" ,"//MxAnchors/MxAnchor/AvailableService/Import/Customize/DefaultCommands" ,"<DefaultCommand>/ROF_INCLUDE_PURGED_DEALS</DefaultCommand>" ,"<DefaultCommands>" );
	frontEndUtilities.ReplaceKeyValueInFileWithEquals( "D:/Migration-Input-Files/migration.props" ,"source.mxversion" ,"2.10.92.trinkaus" ,true );
	frontEndUtilities.AppendToNodeInFileUsingXpath( "D:/Migration-Input-Files/settings1.mxres" ,"//domains/domain[@name='tradeRepository']//setting[@name='EnableDefaultTypologiesCreation']" ,"<setting name = \"Back2BackPackages\"><packages><package><code>B2B</code><mainTradeIndex>0</mainTradeIndex></package><package><code>B2BE</code><mainTradeIndex>0</mainTradeIndex></package><package><code>B2BI</code><mainTradeIndex>0</mainTradeIndex></package><package><code>B2IE</code><mainTradeIndex>0</mainTradeIndex></package></packages></setting>" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/settings1.mxres" ,"//domains/domain[@name='tradeRepository']//setting[@name='EnableDefaultTypologiesCreation']//text()" ,"99" );
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild( "D:/Migration-Input-Files/settings1.mxres" ,"//domains/domain[@name='tradeRepository']//setting[@name='LtiCode2FreePackage']/packages" ,"<package><code>SUM1</code></package>" ,"<packages>" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/settings1.mxres" ,"//domains/domain[@name='generalRights']//setting[@name='DefaultMigrationRights']//text()" ,"0" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/settings1.mxres" ,"//domains/domain[@name='RefreshOptimizationFields']//setting[@name='Scanner']//text()" ,"3" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/settings1.mxres" ,"//domains/domain[@name='RefreshOptimizationFields']//setting[@name='ROFIncludeTypologiesMigration']//text()" ,"true" );
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild( "D:/Migration-Input-Files/settings.mxres" ,"//MxAnchors/MxAnchor[@Code='Target']" ,"<TemplateName>PC_PROC_TPL</TemplateName>" ,"<MxAnchor Code=\"Target\">" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[1]/text()" ,"/USER:MUREXFO" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[2]/text()" ,"/PASSWORD:0010002000410047001600f70067" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[3]/text()" ,"/GROUP:TSS BO" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[4]/text()" ,"/DESK:BO" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[1]/text()" ,"/USER:MUREXFO" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[2]/text()" ,"/PASSWORD:0010002000410047001600f70067" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[3]/text()" ,"/GROUP:TSS BO" );
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( "D:/Migration-Input-Files/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[4]/text()" ,"/DESK:BO" );
	frontEndUtilities.AppendTextToFile( "D:/Migration-Input-Files/launchall.sh" ,"launchmxj.app -aagent" );
	frontEndUtilities.AppendTextToFile( "D:/Migration-Input-Files/launchall.sh" ,"sleep 10" );
	frontEndUtilities.AppendTextToFile( "D:/Migration-Input-Files/launchall.sh" ,"launchmxj.app -rtbs" );
	frontEndUtilities.AppendTextToFile( "D:/Migration-Input-Files/launchall.sh" ,"sleep 10" );
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild( "D:/Migration-Input-Files/launcherall.xml" ,"//AvailableService[Code/text()='MXDATAPUBLISHER']//DefaultCommands" ,"<MxInclude MxAnchor=\"public.mxres.common.defaultarguments.mxres#MXRESDefaultArguments\" MxAnchorType=\"Include\"/>" ,"<DefaultCommands>" );
	//End-Operations
		
def PROP_GenericProp = properties.get("GenericProp");


}}





















