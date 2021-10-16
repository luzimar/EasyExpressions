# EasyExpressions

## Features
- Combine expressions using boolean operators (And, Or)

## Use Case
Expression<Func<People, bool>> filter = x => true;

if(condition)
  filter = filter.And(x => x.LastName.Equals(lastName));
  
if(otherCondition)
  filter = filter.Or(x => x.Age == age);

//Example repository of database
var result = context.People.Where(filter);


## Installation
dotnet add package EasyExpressions

## License
MIT

**Free Software, Hell Yeah!**
