using System;
using System.Linq;
using LoN.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoN.Model.Models;
using LoN.Model.Interfaces;
using LoN.Model.Repositories;
using LoN.View.ViewModel;
using System.Collections;

namespace LoN.Test.Tests
{
    [TestClass]
    public class CrudEquipTest
    {
        private IGenericRepository<Equip> equipRepo;
        private IGenericRepository<Category> catRepo;
        private CrudViewModel equipVM;

        [TestInitialize]
        public void TestInitialize() 
        {
            this.equipRepo = new DummyEquipRepository();
            this.catRepo = new DummyCategoryRepository();
            
            this.equipVM = new CrudViewModel(this.catRepo, this.equipRepo);
        }

        [TestMethod]
        public void TestCreate()
        {
            int catId = 1;
            
            var maxBefore = equipRepo.GetAll().Max(x => x.EquipId);

            equipVM.SelectedCategory = new CategoryViewModel(catRepo.GetOne(catId)); //Doesn't really matter too much, so long as they stay the same
            equipVM.CreateEquipVM();

            var maxAfter = equipRepo.GetAll().Max(x => x.EquipId);

            Assert.AreEqual(maxBefore + 1, maxAfter);//Something has been added to the list.

            var lastAdded = equipRepo.GetAll().Where(x => x.EquipId == equipRepo.GetAll().Max(y => y.EquipId)).ToList()[0];
            
            Assert.IsNotNull(lastAdded);
            Assert.IsInstanceOfType(lastAdded, (new Equip()).GetType());
        }

        [TestMethod]
        public void TestUpdate() 
        {
            var eqId = 5;
            
            var e = equipRepo.GetOne(eqId);
            var eqvm = new EquipViewModel(e);
            equipVM.SelectedEquip = eqvm;

            eqvm.Agillity = 5;
            eqvm.Intelligence = 6;
            eqvm.Strength = -20;
            eqvm.Price = 100;

            Assert.AreNotEqual(eqvm, new EquipViewModel(equipRepo.GetOne(eqId))); //before update check diff.

            var maxBefore = equipRepo.GetAll().Max(x => x.EquipId);

            equipVM.UpdateEquipVM();

            var maxAfter = equipRepo.GetAll().Max(x => x.EquipId);

            Assert.AreEqual(maxBefore, maxAfter); //Check if nothing has been added

            var updated = new EquipViewModel(equipRepo.GetOne(eqId));

            Assert.AreEqual(eqvm, updated); //Check if they are equal after the update.
        }
    }
}
