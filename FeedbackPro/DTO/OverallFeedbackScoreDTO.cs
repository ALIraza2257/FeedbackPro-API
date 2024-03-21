using System.ComponentModel.DataAnnotations.Schema;


namespace FeedbackPro.DTO
{
    public class OverallFeedbackScoreDTO
    {

        public int OneStar { get; set; }
        public int TwoStar { get; set; }
        public int ThreeStar { get; set; }
        public int FourStar { get; set; }
        public int FiveStar { get; set; }
        

        public int Total
        {
            get
            {
                return this.OneStar + this.TwoStar + this.ThreeStar + this.FourStar + this.FiveStar;
            }
        }
        public decimal ScoreWithStar
        {
            get
            {
                return (this.OneStar * 1) + (this.TwoStar * 2) + (this.ThreeStar * 3) + (this.FourStar * 4) + (this.FiveStar * 5);
            }
        }
        public decimal AverageScore
        {
            get
            {
                return Math.Round(this.ScoreWithStar / this.Total,2);
            }
        }


        public decimal OneStarPercentage
        {
            get
            {
                return Math.Round(this.Total == 0 ? 0 : (decimal)this.OneStar / this.Total * 100,2);

            }
        }
        public decimal TwoStarPercentage
        {
            get
            {
                return Math.Round(this.Total == 0 ? 0 : (decimal)this.TwoStar / this.Total * 100, 2);

            }
        }
        public decimal ThreeStarPercentage
        {
            get
            {
                return Math.Round(this.Total == 0 ? 0 : (decimal)this.ThreeStar / this.Total * 100,2);

            }
        }
        public decimal FourStarPercentage
        {
            get
            {
                return Math.Round(this.Total == 0 ? 0 : (decimal)this.FourStar / this.Total * 100, 2);

            }
        }
        public decimal FiveStarPercentage
        {
            get
            {
                return Math.Round(this.Total == 0 ? 0 : (decimal)this.FiveStar / this.Total * 100, 2);

            }
        }
    }

    public class ScoreDTO
    {
        public int? QrcodeId { get; set; }
        public int? NumberofDays { get; set; }
    }

   
}
