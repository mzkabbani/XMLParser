<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
<xsl:template match="@*|node()">
  <xsl:copy>
    <xsl:apply-templates select="@*|node()"/>
  </xsl:copy>
</xsl:template>
<xsl:template match="#TARGETPATH#">
  #STARTTAG#
     <xsl:apply-templates select="@* | *"/>
    #REPLACEMENTXML#
  #ENDTAG#
</xsl:template>
</xsl:stylesheet>
