using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bogus;
using server.Api.Models;
using server.Api.Controllers;

namespace server.Data;
public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MassorAvMasarContext(serviceProvider.GetRequiredService<DbContextOptions<MassorAvMasarContext>>()))
        {
            if (context.Dogs!.Any()) { return; }


             var users = new Faker<User>()
                    .RuleFor(a=> a.Username, f=> f.Internet.UserName()) 
                    .RuleFor(a=> a.Password, f=> f.Internet.Password())
                    .RuleFor(a=> a.Email, f=> f.Internet.Email())
                    .Generate(10);

            var random = new String[]{"Mantrailing", "Agility", "Nosework", "Herding", "Canicross", "Mushing", "Weight pulling", "Dock jumping"};

             var sports = new List<Sport>();
             for(var i = 0; i < (random.Count() - 1); i++){
               sports.Add(new Sport() {
                Name = random[i]
               });
             }
            Console.WriteLine("WHAT");


            context.Users?.AddRange(users);
            context.Sports?.AddRange(sports);

            var cities = new String[] { "Stockholm", "Täby", "Huddinge", "Göteborg", "Jokkmokk", "Kista", "Växholm", "Sandhamn", "Sollentuna", "Väsby", "Visby" };
            var ImageUrl = new String[]{
            "https://images.dog.ceo/breeds/australian-shepherd/forest.jpg",
            "https://images.dog.ceo/breeds/australian-shepherd/leroy.jpg",
            "https://images.dog.ceo/breeds/australian-shepherd/pepper.jpg",
            "https://images.dog.ceo/breeds/australian-shepherd/pepper2.jpg",
            "https://images.dog.ceo/breeds/australian-shepherd/sadie.jpg",
             "https://images.dog.ceo/breeds/shiba/shiba-11.jpg",
            "https://images.dog.ceo/breeds/coonhound/n02089078_2478.jpg",
            "https://images.dog.ceo/breeds/spitz-japanese/tofu.jpg",
            "https://images.dog.ceo/breeds/hound-english/n02089973_529.jpg",
            "https://images.dog.ceo/breeds/sheepdog-shetland/n02105855_13407.jpg",
            "https://images.dog.ceo/breeds/frise-bichon/jh-ezio-2.jpg",
            "https://images.dog.ceo/breeds/poodle-miniature/n02113712_919.jpg",
            "https://images.dog.ceo/breeds/bulldog-french/n02108915_1911.jpg",
            "https://images.dog.ceo/breeds/terrier-welsh/lucy.jpg",
            "https://images.dog.ceo/breeds/shihtzu/n02086240_1445.jpg",
            "https://images.dog.ceo/breeds/ridgeback-rhodesian/n02087394_4681.jpg",
            "https://images.dog.ceo/breeds/terrier-australian/n02096294_7456.jpg",
            "https://images.dog.ceo/breeds/frise-bichon/jh-ezio-2.jpg",
            "https://images.dog.ceo/breeds/wolfhound-irish/n02090721_1452.jpg",
            "https://images.dog.ceo/breeds/labradoodle/Cali.jpg",
            "https://images.dog.ceo/breeds/redbone/n02090379_1670.jpg",
            "https://images.dog.ceo/breeds/african/n02116738_10640.jpg",
            "https://images.dog.ceo/breeds/stbernard/n02109525_3346.jpg",
            "https://images.dog.ceo/breeds/whippet/n02091134_3522.jpg",
            "https://images.dog.ceo/breeds/airedale/n02096051_2774.jpg",
            "https://images.dog.ceo/breeds/hound-ibizan/n02091244_2648.jpg",
            "https://images.dog.ceo/breeds/frise-bichon/6.jpg",
            "https://images.dog.ceo/breeds/coonhound/n02089078_3440.jpg",
            "https://images.dog.ceo/breeds/rottweiler/n02106550_4138.jpg",
            "https://images.dog.ceo/breeds/dingo/n02115641_9675.jpg",
            "https://images.dog.ceo/breeds/terrier-welsh/lucy.jpg",
            "https://images.dog.ceo/breeds/eskimo/n02109961_1613.jpg",
            "https://images.dog.ceo/breeds/borzoi/n02090622_7619.jpg",
            "https://images.dog.ceo/breeds/brabancon/n02112706_793.jpg",
            "https://images.dog.ceo/breeds/hound-ibizan/n02091244_569.jpg",
            "https://images.dog.ceo/breeds/segugio-italian/n02090722_002.jpg",
            "https://images.dog.ceo/breeds/terrier-silky/n02097658_1473.jpg",
            "https://images.dog.ceo/breeds/dingo/n02115641_4692.jpg",
            "https://images.dog.ceo/breeds/sheepdog-shetland/n02105855_19002.jpg",
            "https://images.dog.ceo/breeds/germanshepherd/n02106662_18268.jpg",
            "https://images.dog.ceo/breeds/dane-great/n02109047_3643.jpg",
            "https://images.dog.ceo/breeds/poodle-toy/n02113624_9199.jpg",
            "https://images.dog.ceo/breeds/brabancon/n02112706_1970.jpg",
            "https://images.dog.ceo/breeds/poodle-medium/PXL_20210220_100624962.jpg",
            "https://images.dog.ceo/breeds/terrier-scottish/n02097298_9471.jpg",
            "https://images.dog.ceo/breeds/ovcharka-caucasian/IMG_20190628_144817.jpg",
            "https://images.dog.ceo/breeds/finnish-lapphund/mochilamvan.jpg",
            "https://images.dog.ceo/breeds/appenzeller/n02107908_298.jpg",
            "https://images.dog.ceo/breeds/mountain-bernese/n02107683_4515.jpg",
            "https://images.dog.ceo/breeds/terrier-wheaten/n02098105_1532.jpg",
            "https://images.dog.ceo/breeds/hound-walker/n02089867_1452.jpg",
            "https://images.dog.ceo/breeds/terrier-wheaten/n02098105_2066.jpg",
            "https://images.dog.ceo/breeds/setter-irish/n02100877_3463.jpg",
            "https://images.dog.ceo/breeds/dane-great/n02109047_1260.jpg",
            "https://images.dog.ceo/breeds/terrier-border/n02093754_373.jpg",
             "https://images.dog.ceo/breeds/saluki/n02091831_6451.jpg",
            "https://images.dog.ceo/breeds/pointer-germanlonghair/hans4.jpg",
            "https://images.dog.ceo/breeds/terrier-yorkshire/ema.jpg",
            "https://images.dog.ceo/breeds/wolfhound-irish/n02090721_471.jpg",
            "https://images.dog.ceo/breeds/dachshund/harry-646905_640.jpg",
            "https://images.dog.ceo/breeds/bulldog-boston/n02096585_1559.jpg",
            "https://images.dog.ceo/breeds/hound-blood/n02088466_6984.jpg",
            "https://images.dog.ceo/breeds/schnauzer-miniature/n02097047_1115.jpg",
            "https://images.dog.ceo/breeds/spaniel-brittany/n02101388_4002.jpg",
            "https://images.dog.ceo/breeds/wolfhound-irish/n02090721_4362.jpg",
            "https://images.dog.ceo/breeds/papillon/n02086910_2454.jpg",
            "https://images.dog.ceo/breeds/chihuahua/n02085620_1620.jpg",
            "https://images.dog.ceo/breeds/hound-afghan/n02088094_3400.jpg",
            "https://images.dog.ceo/breeds/cattledog-australian/IMG_3056.jpg",
            "https://images.dog.ceo/breeds/hound-afghan/n02088094_1882.jpg",
            "https://images.dog.ceo/breeds/whippet/n02091134_4197.jpg",
            "https://images.dog.ceo/breeds/dane-great/n02109047_2810.jpg",
            "https://images.dog.ceo/breeds/boxer/n02108089_4865.jpg",
            "https://images.dog.ceo/breeds/terrier-irish/n02093991_863.jpg",
            "https://images.dog.ceo/breeds/pug/n02110958_9929.jpg",
            "https://images.dog.ceo/breeds/mix/Milka1.jpg",
            "https://images.dog.ceo/breeds/airedale/n02096051_119.jpg",
            "https://images.dog.ceo/breeds/labradoodle/lola.jpg",
            "https://images.dog.ceo/breeds/ovcharka-caucasian/IMG_20200101_000620.jpg",
            "https://images.dog.ceo/breeds/stbernard/n02109525_6215.jpg",
            "https://images.dog.ceo/breeds/bulldog-boston/n02096585_1753.jpg",
            "https://images.dog.ceo/breeds/pomeranian/n02112018_2699.jpg",
            "https://images.dog.ceo/breeds/terrier-westhighland/n02098286_321.jpg",
            "https://images.dog.ceo/breeds/hound-english/n02089973_4055.jpg",
            "https://images.dog.ceo/breeds/setter-english/n02100735_6658.jpg",
            "https://images.dog.ceo/breeds/saluki/n02091831_3594.jpg",
            "https://images.dog.ceo/breeds/bulldog-english/bunz.jpg",
            "https://images.dog.ceo/breeds/terrier-kerryblue/n02093859_2124.jpg",
            "https://images.dog.ceo/breeds/malinois/n02105162_10076.jpg",
            "https://images.dog.ceo/breeds/brabancon/n02112706_1833.jpg",
            "https://images.dog.ceo/breeds/terrier-yorkshire/img_2384.jpg",
            "https://images.dog.ceo/breeds/collie-border/n02106166_1205.jpg",
            "https://images.dog.ceo/breeds/pointer-germanlonghair/hans2.jpg",
            "https://images.dog.ceo/breeds/samoyed/n02111889_5532.jpg",
            "https://images.dog.ceo/breeds/dalmatian/cooper2.jpg",
            "https://images.dog.ceo/breeds/terrier-silky/n02097658_9727.jpg",
            "https://images.dog.ceo/breeds/spaniel-sussex/n02102480_1810.jpg",
            "https://images.dog.ceo/breeds/dachshund/dachshund_4.jpg",
            "https://images.dog.ceo/breeds/bullterrier-staffordshire/n02093256_3877.jpg",
            "https://images.dog.ceo/breeds/spaniel-irish/n02102973_27.jpg",
            "https://images.dog.ceo/breeds/dane-great/n02109047_12726.jpg",
            "https://images.dog.ceo/breeds/borzoi/n02090622_3210.jpg",
            "https://images.dog.ceo/breeds/terrier-welsh/lucy.jpg",
            "https://images.dog.ceo/breeds/otterhound/n02091635_2112.jpg",
            "https://images.dog.ceo/breeds/komondor/n02105505_3933.jpg",
                "https://images.dog.ceo/breeds/vizsla/n02100583_11701.jpg",
            "https://images.dog.ceo/breeds/pointer-german/n02100236_2542.jpg",
            "https://images.dog.ceo/breeds/ovcharka-caucasian/IMG_20191107_143744.jpg",
            "https://images.dog.ceo/breeds/labrador/n02099712_357.jpg",
            "https://images.dog.ceo/breeds/setter-irish/n02100877_6436.jpg",
            "https://images.dog.ceo/breeds/komondor/n02105505_3721.jpg",
            "https://images.dog.ceo/breeds/keeshond/n02112350_8045.jpg",
            "https://images.dog.ceo/breeds/segugio-italian/n02090722_002.jpg",
            "https://images.dog.ceo/breeds/bouvier/n02106382_4760.jpg",
            "https://images.dog.ceo/breeds/dingo/n02115641_3110.jpg",
            "https://images.dog.ceo/breeds/dane-great/n02109047_875.jpg",
            "https://images.dog.ceo/breeds/mix/Cali-Mini-Labradoodle.jpg",
            "https://images.dog.ceo/breeds/bouvier/n02106382_7656.jpg",
            "https://images.dog.ceo/breeds/komondor/n02105505_2316.jpg",
            "https://images.dog.ceo/breeds/deerhound-scottish/n02092002_885.jpg",
            "https://images.dog.ceo/breeds/dingo/n02115641_6183.jpg",
            "https://images.dog.ceo/breeds/dhole/n02115913_1332.jpg",
            "https://images.dog.ceo/breeds/weimaraner/n02092339_7812.jpg",
            "https://images.dog.ceo/breeds/bulldog-english/murphy.jpg",
            "https://images.dog.ceo/breeds/briard/n02105251_252.jpg",
            "https://images.dog.ceo/breeds/mountain-swiss/n02107574_2377.jpg",
            "https://images.dog.ceo/breeds/buhund-norwegian/hakon1.jpg",
            "https://images.dog.ceo/breeds/collie-border/n02106166_3515.jpg",
            "https://images.dog.ceo/breeds/redbone/n02090379_1542.jpg",
            "https://images.dog.ceo/breeds/briard/n02105251_4569.jpg",
            "https://images.dog.ceo/breeds/labradoodle/labradoodle-forrest.jpg",
            "https://images.dog.ceo/breeds/stbernard/n02109525_1902.jpg",
            "https://images.dog.ceo/breeds/mix/howl_1.jpg",
            "https://images.dog.ceo/breeds/malinois/n02105162_6489.jpg",
            "https://images.dog.ceo/breeds/pembroke/n02113023_6275.jpg",
            "https://images.dog.ceo/breeds/poodle-medium/WhatsApp_Image_2022-08-06_at_4.48.38_PM.jpg",
            "https://images.dog.ceo/breeds/terrier-sealyham/n02095889_784.jpg",
            "https://images.dog.ceo/breeds/terrier-bedlington/n02093647_1022.jpg",
            "https://images.dog.ceo/breeds/bulldog-english/bunz.jpg",
            "https://images.dog.ceo/breeds/eskimo/n02109961_6143.jpg",
            "https://images.dog.ceo/breeds/papillon/n02086910_7949.jpg",
            "https://images.dog.ceo/breeds/mexicanhairless/n02113978_3843.jpg",
            "https://images.dog.ceo/breeds/papillon/n02086910_797.jpg",
            "https://images.dog.ceo/breeds/eskimo/n02109961_997.jpg",
            "https://images.dog.ceo/breeds/labradoodle/Cali.jpg",
            "https://images.dog.ceo/breeds/stbernard/n02109525_950.jpg",
            "https://images.dog.ceo/breeds/pekinese/n02086079_207.jpg",
            "https://images.dog.ceo/breeds/shihtzu/n02086240_8017.jpg",
            "https://images.dog.ceo/breeds/cattledog-australian/IMG_3469.jpg",
            "https://images.dog.ceo/breeds/chihuahua/n02085620_3677.jpg",
            "https://images.dog.ceo/breeds/spaniel-sussex/n02102480_1849.jpg",
            "https://images.dog.ceo/breeds/spaniel-blenheim/n02086646_117.jpg",
            "https://images.dog.ceo/breeds/retriever-golden/n02099601_4241.jpg",
            "https://images.dog.ceo/breeds/hound-walker/n02089867_4001.jpg",
            "https://images.dog.ceo/breeds/shiba/shiba-2.jpg"
            };

            var breeds = new string[]{
                "affenpinscher", "african",
    "airedale",
    "akita",
    "appenzeller",
    "australian shepherd",
    "basenji",
    "beagle",
    "bluetick",
    "borzoi",
    "bouvier","brabancon", "briard", "buhund", "bulldog","boston","french bullterrier","staffordshire", "chihuahua", "chow", "cockapoo",  "coonhound","corgi",
   "cotondetulear",
   "dachshund",
   "dalmatian",
   "dhole",
   "dingo",
   "doberman",
   "german shepherd",
   "groenendael",
   "havanese",
   "hound",
   "husky",
   "keeshond",
   "kelpie",
   "komondor",
   "kuvasz",
   "labradoodle",
   "labrador",
   "leonberg",
   "malamute",
   "malinois",
   "maltese",
   "mastiff",
   "mexican hairless",
   "newfoundland",
   "papillon",
   "pekinese",
   "pembroke",
   "pinscher",
   "pitbull",
   "pointer",
   "pomeranian",
   "poodle",
   "pug",
   "puggle",
   "pyrenees",
   "redbone",
   "retriever",
   "rottweiler",
   "saluki",
   "samoyed",
    "shiba",
    "shihtzu",
    "stbernard",
    };

            // var gender = new string[]{"Female", "Male"};

            // var dogs = new Faker<Dog>()
            // .RuleFor(a => a.Name, f => f.Name.FirstName())
            // .RuleFor(a => a.Age, f => f.Random.Number(1, 15))
            // .RuleFor(a => a.Gender, f => f.Random.ArrayElement<string>(gender))

            // .RuleFor(a => a.Race, f => f.Random.ArrayElement<string>(breeds))
            // .RuleFor(a => a.ImageUrl, f => f.Random.ArrayElement<string>(ImageUrl))


            // .RuleFor(a => a.Location, f => f.Random.ArrayElement<string>(cities))
            // .RuleFor(a => a.SportId, f => f.Random.Number(2, 15))
            // .RuleFor(a => a.UserId, f => f.Random.Number(1, 40))
            // .Generate(75);

            // context.Dogs.AddRange(dogs);
            context.SaveChanges();

            // use bogus here if you can
        }
    }
}