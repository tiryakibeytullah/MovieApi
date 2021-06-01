using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Data.Seeds
{
    public class MovieSeed : IEntityTypeConfiguration<Movie>
    {
        private readonly int[] _ids;
        public MovieSeed(int[] ids)
        {
            this._ids = ids;
        }

        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                    new Movie { Id = 1, Name = "7.Koğuştaki Mucize", ImageUrl = "1.jpg", Time = 3, Subject = "Yedinci Koğuştaki Mucize, 7 yaşındaki kızı ile aynı zeka yaşına sahip bir babanın adalet arayışını konu ediyor. 1983 yılında bir Ege kasabasında küçük bir kız ölür. Ölen küçük kız sıkıyönetim komutanının kızıdır ve onun ölümünün sorumlusu olarak babaannesi ile yaşayan ve 7 yaşında bir kızı olan Memo görülür.", CategoryId = _ids[0] },
                    new Movie { Id = 2, Name = "Esaretin Bedeli", ImageUrl = "2.jpg", Time = 3, Subject = "Stephen King'in Rita Hayworth ve Shawshank'in Kefareti adlı novellasından uyarlanan film, masumiyetini iddia etmesine rağmen karısını ve sevgilisini öldürdüğü gerekçesiyle Shawshank Devlet Cezaevi'nde yaklaşık 20 yılını geçiren bankacı Andy Dufresne'in hikâyesini anlatır.", CategoryId = _ids[0] },
                    new Movie { Id = 3, Name = "The Platform", ImageUrl = "3.jpg", Time = 2, Subject = "The Platform filmi, Her katında sadece iki kişinin bulunduğu ve çok katlı olan bir hapishanede yaşanılan sınıfsal ayrımları ve haksızlıkları anlatıyor. Hapishanede dağıtılan yemekler ilk başta en üst katta olanlara veriliyor, artan yemekler ise bir alt kattakine gidiyor.", CategoryId = _ids[1] },
                    new Movie { Id = 4, Name = "Extraction", ImageUrl = "4.jpg", Time = 3, Subject = "Extraction, silah satıcıları ve kaçakçılara ait bir dünyada, uyuşturucu lordları arasında geçen savaşta piyon olan genç bir çocuğun hikayesini konu ediliyor. Kaçırılıp, dünyanın en ücra şehrine gönderilen Hintli çocuğun işadamı olan babası, oğlunu kurtarması için bir adam kiralar.", CategoryId = _ids[2] },
                    new Movie { Id = 5, Name = "Aykut Enişte", ImageUrl = "5.jpg", Time = 2, Subject = "Aykut Enişte, yalnızlığından şikayetçi olan ve aile özlemi çeken bir adam olan Aykut'un hikayesini konu ediyor. Aykut, evlenip yuva kurmanın hayali ile yaşayan genç bir adamdır. ... Dükkana bakmak için sigortadan gelen Gülşah'ın, Aykut'tan küçük bir iyilik istemesi hepsinin hayatının değişmesine neden olur.", CategoryId = _ids[3] },
                    new Movie { Id = 6, Name = "Kolpaçino", ImageUrl = "6.jpg", Time = 2, Subject = "Tayfun, İstanbul'un ünlü suç adamlarından Ateş'in yanında çalışmaktadır. Kendisinden mal çaldığını düşünen Ateş, Tayfun'u 10 gün içinde eksilen mallarını geri getirmek ve 50 bin dolarla cezalandırır. Tayfun bu parayı bulmak için Dolapdereli Sabri'den yardım ister.", CategoryId = _ids[3] }
                );
        }
    }
}
