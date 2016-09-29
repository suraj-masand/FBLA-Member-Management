using FBLA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace FBLA
{
    // FBLAMember class represents the member object for each member in the system
    public class FBLAMember
    {
        // Properties of the FBLAMember class
        public int Id { get; set; }
        public string MembershipNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
        public string USstate { get; set; }
        public int SchoolGrade { get; set; }
        public string Active { get; set; }
        public int YearJoined { get; set; }
        public decimal AmountOwed { get; set; }

        // Gets the member object by the membership number
        public static FBLAMember getMemberByMembershipNumber(string membershipNumber)
        {
            FBLAMember member = null;

            string queryString = "SELECT * FROM Membership WHERE membershipNumber = @membershipNumber";

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@membershipNumber", membershipNumber));

            SQLiteDataAdapter ad = DButils.getDBData(queryString.ToString(), paramList);

            DataSet ds = new DataSet();
            ad.Fill(ds, "fblaMember");
            if (ds.Tables["fblaMember"].Rows.Count == 1) // we found one record with this membership number
            {
                member = new FBLAMember();
                member.Id = Convert.ToInt32(ds.Tables["fblaMember"].Rows[0]["id"]);
                member.MembershipNumber = ds.Tables["fblaMember"].Rows[0]["membershipNumber"].ToString();
                member.FirstName = ds.Tables["fblaMember"].Rows[0]["firstName"].ToString();
                member.LastName = ds.Tables["fblaMember"].Rows[0]["lastName"].ToString();
                member.Email = ds.Tables["fblaMember"].Rows[0]["email"].ToString();
                member.School = ds.Tables["fblaMember"].Rows[0]["school"].ToString();
                member.USstate = ds.Tables["fblaMember"].Rows[0]["USstate"].ToString();
                member.SchoolGrade = Convert.ToInt32(ds.Tables["fblaMember"].Rows[0]["schoolGrade"]);
                member.AmountOwed = Convert.ToDecimal(ds.Tables["fblaMember"].Rows[0]["amountOwed"]);
                member.Active = ds.Tables["fblaMember"].Rows[0]["active"].ToString();
                member.YearJoined = Convert.ToInt32(ds.Tables["fblaMember"].Rows[0]["yearJoined"]);
            }

            return member;
        }

        // Adds a new member to the database
        public static bool addMember(FBLAMember newMember)
        {
            string insertNewMemberQuery = "INSERT INTO Membership " + 
                "(membershipNumber, firstName, lastName, email, schoolGrade, school, USstate, yearJoined, active, amountOwed) " + 
                "VALUES (@memberNum, @fName, @lName, @email, @schoolGrade, @school,@USstate, @yearJoined, @active, @amountOwed)";

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@memberNum", newMember.MembershipNumber));
            paramList.Add(new SQLiteParameter("@fName", newMember.FirstName));
            paramList.Add(new SQLiteParameter("@lName", newMember.LastName));
            paramList.Add(new SQLiteParameter("@email", newMember.Email));
            paramList.Add(new SQLiteParameter("@schoolGrade", newMember.SchoolGrade));
            paramList.Add(new SQLiteParameter("@school", newMember.School));
            paramList.Add(new SQLiteParameter("@USstate", newMember.USstate));
            paramList.Add(new SQLiteParameter("@yearJoined", newMember.YearJoined));
            paramList.Add(new SQLiteParameter("@active", newMember.Active));
            paramList.Add(new SQLiteParameter("@amountOwed", newMember.AmountOwed));

            return DButils.storeData(insertNewMemberQuery, paramList);
        }

        // Updates an existing member in the database
        public static bool updateMember(FBLAMember newMember)
        {
            string updateMemberQuery = "UPDATE Membership SET membershipNumber = @memberNum, " +
            "firstName = @fName, " +
            "lastName = @lName, " +
            "email = @email, " +
            "schoolGrade = @schoolGrade, " +
            "school = @school, " +
            "USstate = @USstate, " +
            "yearJoined = @yearJoined, " +
            "active = @active, " +
            "amountOwed = @amountOwed " +
            "WHERE id = @id";

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@memberNum", newMember.MembershipNumber));
            paramList.Add(new SQLiteParameter("@fName", newMember.FirstName));
            paramList.Add(new SQLiteParameter("@lName", newMember.LastName));
            paramList.Add(new SQLiteParameter("@email", newMember.Email));
            paramList.Add(new SQLiteParameter("@schoolGrade", newMember.SchoolGrade));
            paramList.Add(new SQLiteParameter("@school", newMember.School));
            paramList.Add(new SQLiteParameter("@USstate", newMember.USstate));
            paramList.Add(new SQLiteParameter("@yearJoined", newMember.YearJoined));
            paramList.Add(new SQLiteParameter("@active", newMember.Active));
            paramList.Add(new SQLiteParameter("@amountOwed", newMember.AmountOwed));
            paramList.Add(new SQLiteParameter("@id", newMember.Id));

            return DButils.storeData(updateMemberQuery, paramList);
        }

        // Deletes a member from the database using the internal ID number
        public static bool deleteMember(int memberId)
        {
            string deleteMemberQuery = "DELETE FROM Membership WHERE id = @id";

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@id", memberId));

            return DButils.storeData(deleteMemberQuery, paramList);
        }
    }
}
