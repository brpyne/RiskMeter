using System;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper.PageScrapers
{
    public class CrimeDataScraper : DataScraper
    {
        public CrimeDataScraper(string city, string state)
            : base("crime-"+city+"-"+state+".html")
        {
        }

        public void GetData()
        {
            HtmlNode crimeTableNode = Document.GetElementbyId("crimeTab");

            Console.WriteLine(crimeTableNode.WriteContentTo());
            // Returns the following...

            // thead
            //      tr/th/h4 Type, Year (x13)
            //      tbody
            //          tr/td[0]/b Type Value
            //          tr/td[1-13] Statistic Value Year (x + 2000)

            /*
<thead>
<tr><th colspan='14'><h3>Crime rates in Detroit by Year</h3></th></tr>
<tr><th width='200'><h4>Type</h4></th>
<th><h4>2000</h4></th>
<th><h4>2001</h4></th>
<th><h4>2002</h4></th>
<th><h4>2003</h4></th>
<th><h4>2004</h4></th>
<th><h4>2005</h4></th>
<th><h4>2006</h4></th>
<th><h4>2007</h4></th>
<th><h4>2008</h4></th>
<th><h4>2009</h4></th>
<th><h4>2010</h4></th>
<th><h4>2011</h4></th>
<th><h4>2012</h4></th>
</tr>
</thead>
<tbody>
<tr><td><b>Murders</b><br><small>(per 100,000)</small></td><td>396<br><small>(40
.7)</small></td><td>395<br><small>(41.3)</small></td><td>402<br><small>(41.8)</s
mall></td><td>366<br><small>(39.4)</small></td><td>385<br><small>(42.1)</small><
/td><td>354<br><small>(39.3)</small></td><td>418<br><small>(47.3)</small></td><t
d>394<br><small>(45.8)</small></td><td>306<br><small>(33.8)</small></td><td>365<
br><small>(40.2)</small></td><td>310<br><small>(34.5)</small></td><td>344<br><sm
all>(48.2)</small></td><td>386<br><small>(54.6)</small></td></tr>

<tr><td><b>Rapes</b><br><small>(per 100,000)</small></td><td>811<br><small>(83.4
)</small></td><td>652<br><small>(68.2)</small></td><td>708<br><small>(73.6)</sma
ll></td><td>814<br><small>(87.7)</small></td><td>719<br><small>(78.6)</small></t
d><td>589<br><small>(65.4)</small></td><td>593<br><small>(67.0)</small></td><td>
341<br><small>(39.6)</small></td><td>330<br><small>(36.4)</small></td><td>335<br
><small>(36.9)</small></td><td>405<br><small>(45.0)</small></td><td>427<br><smal
l>(59.9)</small></td><td>441<br><small>(62.4)</small></td></tr>

<tr><td><b>Robberies</b><br><small>(per 100,000)</small></td><td>7,868<br><small
>(809.1)</small></td><td>7,096<br><small>(742.0)</small></td><td>6,288<br><small
>(653.6)</small></td><td>5,817<br><small>(627.0)</small></td><td>5,451<br><small
>(596.2)</small></td><td>6,820<br><small>(757.0)</small></td><td>7,240<br><small
>(818.6)</small></td><td>6,575<br><small>(763.7)</small></td><td>6,115<br><small
>(675.1)</small></td><td>5,913<br><small>(650.9)</small></td><td>5,538<br><small
>(615.7)</small></td><td>4,962<br><small>(695.7)</small></td><td>4,843<br><small
>(684.9)</small></td></tr>

<tr><td><b>Assaults</b><br><small>(per 100,000)</small></td><td>13,037<br><small
>(1,340.7)</small></td><td>12,804<br><small>(1,338.9)</small></td><td>12,542<br>
<small>(1,303.8)</small></td><td>11,727<br><small>(1,264.0)</small></td><td>9,35
8<br><small>(1,023.5)</small></td><td>13,477<br><small>(1,495.9)</small></td><td
>13,143<br><small>(1,486.0)</small></td><td>12,398<br><small>(1,440.0)</small></
td><td>10,677<br><small>(1,178.8)</small></td><td>11,255<br><small>(1,238.9)</sm
all></td><td>10,723<br><small>(1,192.2)</small></td><td>9,512<br><small>(1,333.6
)</small></td><td>9,341<br><small>(1,321.0)</small></td></tr>

<tr><td><b>Burglaries</b><br><small>(per 100,000)</small></td><td>15,828<br><sma
ll>(1,627.7)</small></td><td>15,096<br><small>(1,578.6)</small></td><td>14,399<b
r><small>(1,496.8)</small></td><td>14,100<br><small>(1,519.8)</small></td><td>12
,202<br><small>(1,334.5)</small></td><td>15,304<br><small>(1,698.7)</small></td>
<td>18,134<br><small>(2,050.3)</small></td><td>17,767<br><small>(2,063.6)</small
></td><td>17,818<br><small>(1,967.1)</small></td><td>18,993<br><small>(2,090.7)<
/small></td><td>17,090<br><small>(1,900.1)</small></td><td>15,994<br><small>(2,2
42.4)</small></td><td>13,488<br><small>(1,907.5)</small></td></tr>

<tr><td><b>Thefts</b><br><small>(per 100,000)</small></td><td>31,929<br><small>(
3,283.6)</small></td><td>29,613<br><small>(3,096.7)</small></td><td>26,839<br><s
mall>(2,790.0)</small></td><td>25,353<br><small>(2,732.7)</small></td><td>20,640
<br><small>(2,257.3)</small></td><td>17,383<br><small>(1,929.4)</small></td><td>
21,287<br><small>(2,406.8)</small></td><td>20,918<br><small>(2,429.6)</small></t
d><td>18,836<br><small>(2,079.5)</small></td><td>18,574<br><small>(2,044.6)</sma
ll></td><td>18,095<br><small>(2,011.8)</small></td><td>16,456<br><small>(2,307.2
)</small></td><td>15,968<br><small>(2,258.3)</small></td></tr>

<tr><td><b>Auto thefts</b><br><small>(per 100,000)</small></td><td>25,892<br><sm
all>(2,662.7)</small></td><td>24,537<br><small>(2,565.9)</small></td><td>23,857<
br><small>(2,480.0)</small></td><td>25,356<br><small>(2,733.0)</small></td><td>2
4,573<br><small>(2,687.5)</small></td><td>21,285<br><small>(2,362.6)</small></td
><td>22,917<br><small>(2,591.1)</small></td><td>19,617<br><small>(2,278.5)</smal
l></td><td>16,441<br><small>(1,815.1)</small></td><td>13,011<br><small>(1,432.2)
</small></td><td>12,602<br><small>(1,401.1)</small></td><td>11,368<br><small>(1,
593.9)</small></td><td>11,500<br><small>(1,626.4)</small></td></tr>

<tr><td><b>Arson</b><br><small>(per 100,000)</small></td><td>2,015<br><small>(20
7.2)</small></td><td>1,634<br><small>(170.9)</small></td><td>2,429<br><small>(25
2.5)</small></td><td>1,744<br><small>(188.0)</small></td><td>1,734<br><small>(18
9.6)</small></td><td>936<br><small>(103.9)</small></td><td>859<br><small>(97.1)<
/small></td><td>758<br><small>(88.0)</small></td><td>691<br><small>(76.3)</small
></td><td>624<br><small>(68.7)</small></td><td>1,082<br><small>(120.3)</small></
td><td>957<br><small>(134.2)</small></td><td>562<br><small>(79.5)</small></td></
tr>

<tfoot><tr class='nosort'><td><b>City-data.com crime rate</b> (higher means more
 crime, U.S. average = 301.1)</td><td>1148.0</td><td>1096.5</td><td>1041.9</td><
td>1052.4</td><td>954.9</td><td>1070.9</td><td>1169.3</td><td>1093.4</td><td>925
.8</td><td>920.2</td><td>877.1</td><td>1023.9</td><td>1009.7</td></tr>
</tfoot>
</tbody>

*/
        }
    }
}