using FlowerWebsite.Model.Entitys;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FlowerWebsite.Common
{
    public class DbContext
    {
        public static SqlSugarClient db;

        static DbContext()
        {
            // Ensure the current directory is set correctly
            var basePath = Directory.GetCurrentDirectory();

            // Create a configuration builder to read from appsettings.json
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath) // Set the base path to the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Add appsettings.json

            IConfiguration configuration = configurationBuilder.Build(); // Build the configuration

            // Read the connection string from appsettings.json
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Initialize the SqlSugarClient with the connection string
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
            });
        }
        //public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        //{
        //    //ConnectionString = "",
        //    ConnectionString = "",
        //    DbType = DbType.SqlServer,
        //    IsAutoCloseConnection = true,
        //});


        public static void InitDataBase()
        {
            db.DbMaintenance.CreateDatabase();

            string nspace = "FlowerWebsite.Modal.Entitys";
            Type[] types = Assembly.LoadFrom("bin/Debug/net6.0/FlowerWebsite.Modal.dll").GetTypes().Where(p => p.Namespace == nspace).ToArray();
            db.CodeFirst.SetStringDefaultLength(200).InitTables(types);

            List<Flower> flowers = new List<Flower>()
            {
                #region 爱情鲜花
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a1.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=200
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a2.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=201
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a3.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=202
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a4.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=203
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a5.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=204
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a6.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=205
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a7.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=206
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a8.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=207
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=1 },
	            #endregion
                #region 生日鲜花
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s1.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=300
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s2.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=301
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s3.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=302
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s4.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=303
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s5.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=304
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s6.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=305
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s7.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=306
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s8.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=307
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=2 },
	            #endregion
                #region 友情鲜花
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y1.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=100
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y2.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=101
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y3.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=102
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y4.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=103
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y5.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=104
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y6.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=105
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y7.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=106
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y8.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=107
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=3 },
	            #endregion
                #region 婚庆鲜花
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a1.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=500
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s1.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=501
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y1.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=502
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a2.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=503
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s2.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=504
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/y2.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=505
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/a3.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=506
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
                new Flower(){ Title ="韩式系列/公主的假日"
                ,Image="/images/content/s3.jpg"
                ,BigImage="/images/detail/202004091613483166.jpg"
                ,Description="[甜美的公主，今夜你最美]粉玫瑰11枝、白色洋桔梗5枝、大叶尤加利10枝"
                ,Price=507
                ,Language="娇羞的粉色戴安娜玫瑰与清新的白色洋桔梗，经过花艺师之手赋予了爱的意义，将这份藏于心底的爱，包裹在粉色中幸会，今晚你好吗？今夜的美妙愿你永远记住，你是我心中最甜美的公主!"
                ,Material="韩式花束系列：戴安娜粉玫瑰11枝、3头或以上白色洋桔梗5枝、大叶尤加利10枝"
                ,Packing="嫣粉/玫粉色欧雅纸6张、白色OPP雾面纸3张、樱花粉色罗纹烫金丝带2米"
                ,DeliveryRemarks="江浙沪包邮，偏远地区除外，小城市请提前一天预定"
                ,Type=4 },
	            #endregion
            };
            db.Insertable(flowers).ExecuteCommand();
        }
    }
}
