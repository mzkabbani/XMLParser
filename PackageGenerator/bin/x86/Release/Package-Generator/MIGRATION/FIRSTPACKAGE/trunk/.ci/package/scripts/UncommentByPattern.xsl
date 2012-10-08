<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
 <xsl:output omit-xml-declaration="yes" indent="yes"/>
 <xsl:strip-space elements="*"/>

 <xsl:template match="Storage" >
    <xsl:copy>
        <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
</xsl:template>

<xsl:template match="comment()">
    <xsl:value-of disable-output-escaping="yes" select="substring-after(.,'domain name = &quot;generalRights')"/>
</xsl:template>
</xsl:stylesheet>