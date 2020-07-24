
/// <CardBased/Version1.0>
/// 1.Canvas之间跳转
/// 2.可选择player,读表初始化player
/// 3.读表初始化关卡
/// 4.读表初始化enemy
/// 5.实现物体点击响应
/// 6.实现牌堆逻辑
/// 
/// </summary>
/// 

//待解决的问题
//1. Id:作为表内行数据的索引,在表内是唯一的;当场景中实例多个相同元素时,增加字段Counter,作为序号标识
//      当卡牌被销毁时,Counter需要重新排序,不能用Counter--处理,以保证Counter连贯
//2. 如果单张卡牌有最大数量限制,可以用Counter=MaxCounter作为条件;或者增加字段CanGet=true;
//      当Counter=MaxCounter,或CanGet=false;该卡不能继续获得
//      Counter与CanGet需要写表才能在初始化时起到作用
//3. 写表的方法
//   